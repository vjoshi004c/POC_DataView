using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POC_DataView
{
    public partial class EditUser : System.Web.UI.Page
    {
        private string CONNECTION_STRING = "Data Source=LAPTOP-7KMD6RSV; Initial Catalog=AshiDB;Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string userid = string.Empty;
                if (Request.QueryString["userid"] != null)
                {
                    userid = Request.QueryString["userid"].ToString();
                    if (userid != string.Empty)
                    {
                        getUser(Convert.ToInt32(userid));
                    }
                }
            }


        }

        private void getUser(int userid )
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(CONNECTION_STRING);
            con.Open();

          //  cmd = new SqlCommand("getUser", con);
             cmd = new SqlCommand("select UserID, UserName, UserPassword, UserEmail, UserImage from dbo.[User] where userid ="+ userid, con);

           // cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = userRequest.User.UserEmail;
           // cmd.Parameters.Add("@userpassword", SqlDbType.NVarChar).Value = userRequest.User.UserPassword;


            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                txtUserID.Text = reader["UserID"].ToString(); ;
                txtUserName.Text = reader["UserName"].ToString();
                txtUserPassword.Text = reader["UserPassword"].ToString();
                txtUserEmail.Text = reader["UserEmail"].ToString();
                txtUserImage.Text = reader["UserImage"].ToString();
            }
        }

       
        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(txtUserID.Text);
            string username = txtUserName.Text;
            string useremail = txtUserEmail.Text;
            string userimage = txtUserImage.Text;
            string userpassword = txtUserPassword.Text;
            editUser(userid, username, useremail, userpassword, userimage);
             Response.Redirect("TestGridView.aspx");
        }
        protected void btnShowListView_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestGridViewSecond.aspx");
        }

        private void editUser(int userid, string username , string useremail , string userpassword, string userimage)
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            string SqlQuery = "Update dbo.[User] set  username ='" + username + "', userpassword='" + userpassword + "', userimage='" + userimage + "', useremail ='" + useremail + "' where userid =" + userid;
            cmd = new SqlCommand(SqlQuery, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("TestGridView.aspx");

        }
    }
}