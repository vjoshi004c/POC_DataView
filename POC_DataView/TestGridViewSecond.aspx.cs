using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace POC_DataView
{
  
    public partial class TestGridViewSecond : System.Web.UI.Page
    {
        private string CONNECTION_STRING = "Data Source=LAPTOP-7KMD6RSV; Initial Catalog=AshiDB;Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
               
                dt = GetAllUser();
                dListUser.DataSource = dt;
                dListUser.DataBind();

                
            }
        }
        protected void dListUser_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "View")
            {
                string name = (e.Item.FindControl("lblUserName") as Label).Text;
                string useremail = (e.Item.FindControl("lblUserEmail") as Label).Text;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nEmail: " + useremail + "');", true);
            }
            if (e.CommandName == "Edit User")
            {

                string userid = (e.Item.FindControl("lblUserID") as Label).Text;
                string name = (e.Item.FindControl("lblUserName") as Label).Text;
                string useremail = (e.Item.FindControl("lblUserEmail") as Label).Text;

                Response.Redirect("EditUser.aspx?userid=" + userid);

            }

            if (e.CommandName == "Delete User")
            {

                string userid = (e.Item.FindControl("lblUserID") as Label).Text;
                string name = (e.Item.FindControl("lblUserName") as Label).Text;
                string useremail = (e.Item.FindControl("lblUserEmail") as Label).Text;
                deleteUser(Convert.ToInt32(userid));
                 Response.Redirect("TestGridViewSecond.aspx");

            }
        }
        protected void dListUser_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) ||
             (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Image ImgUserImage = e.Item.FindControl("imgUserImage") as Image;
                ImgUserImage.ImageUrl = "~/Images/User1/" + ImgUserImage.ImageUrl;


            }

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }
        public DataTable GetAllUser()
        {
            // DataTable dt = new DataTable();
            try
            {
                SqlConnection con;
                //SqlCommand cmd = new SqlCommand();
                con = new SqlConnection(CONNECTION_STRING);
                con.Open();

                // SqlDataAdapter da = new SqlDataAdapter(cmd);
                // DataTable dt = new DataTable();
                //  da.Fill(dt);

                SqlCommand cmd1 = new SqlCommand("select UserID, UserName, UserPassword, UserEmail, UserImage from dbo.[User] order by userid desc", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                con.Close();
                return dt1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void deleteUser(int userid)
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            cmd = new SqlCommand("Delete from dbo.[User]  where userid =" + userid, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("TestGridView.aspx");

        }

        protected void btnShowListView_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestGridView.aspx");
        }
    }
}