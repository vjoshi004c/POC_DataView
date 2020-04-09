using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POC_DataView
{
    public partial class AddUser : System.Web.UI.Page
    {
        private string CONNECTION_STRING = "Data Source=LAPTOP-7KMD6RSV; Initial Catalog=AshiDB;Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
           
            string username = txtUserName.Text;
            string useremail = txtUserEmail.Text;
            string userpassword = txtUserPassword.Text;
            string userImage = txtUserImage.Text;
            addUser( username, useremail, userpassword, userImage);
            Response.Redirect("TestGridView.aspx");
           

        }
        private void addUser(string username, string useremail, string userpassword, string userImage)
        {
            SqlConnection con;
            SqlCommand cmd = new SqlCommand();
            con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            string SqlQuery = "Insert into  dbo.[User] (username, userpassword,userimage, useremail) values (' " +username + "','" + userpassword + "','" + userImage + "','" + useremail + "')";
            cmd = new SqlCommand(SqlQuery, con);
            cmd.ExecuteNonQuery();
            Response.Redirect("TestGridView.aspx");

        }
        protected void btnShowListView_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestGridViewSecond.aspx");
        }
    }
}