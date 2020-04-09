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
    public partial class TestGridView : System.Web.UI.Page
    {
        private string CONNECTION_STRING = "Data Source=LAPTOP-7KMD6RSV; Initial Catalog=AshiDB;Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                //dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
                //dt.Rows.Add(1, "John Hammond", "United States");
                //dt.Rows.Add(2, "Mudassar Khan", "India");
                //dt.Rows.Add(3, "Suzanne Mathews", "France");
                //dt.Rows.Add(4, "Robert Schidner", "Russia");

                dt = GetAllUser();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        public DataTable GetAllUser()
        {
            try
            {
                SqlConnection con;
                con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                
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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               Image ImgUserImage = e.Row.FindControl("imgUserImage") as Image;
                // ImgUserImage.ImageUrl = "~/Images/User1/" + e.Row.Cells[2].Text;

                ImgUserImage.ImageUrl = "~/Images/User1/" + ImgUserImage.ImageUrl;
            }

        }
        
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[rowIndex];
                string name = (row.FindControl("txUserName") as TextBox).Text;

                string useremail = row.Cells[3].Text;

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nEmail: " + useremail + "');", true);
            }
            if (e.CommandName == "Edit User")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[rowIndex];
                string userid = (row.FindControl("txtUserID") as TextBox).Text;
                string name = (row.FindControl("txUserName") as TextBox).Text;

                string useremail = row.Cells[3].Text;

                Response.Redirect("EditUser.aspx?userid="+ userid);

            }

            if (e.CommandName == "Delete User")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[rowIndex];
                string userid = (row.FindControl("txtUserID") as TextBox).Text;
                string name = (row.FindControl("txUserName") as TextBox).Text;
                string useremail = row.Cells[2].Text;
                deleteUser(Convert.ToInt32(userid));
                Response.Redirect("TestGridViewSecond.aspx");

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

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }
        protected void btnShowListView_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestGridViewSecond.aspx");
        }
        
    }
}