using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace TropicalServer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if(Request.Cookies["username"] != null)
                {
                    usernametextbox.Text = Request.Cookies["username"].Value;
                }
            }          
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString);          
            conn.Open();
            string checkuser = "Select count(*) from tblTropicalUser where LoginID= '"+ usernametextbox.Text+"'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp == 1)
            {
                string checkPasswordQuery = "select Password from tblTropicalUser where LoginID='" + usernametextbox.Text + "'";
                SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
                string password = passComm.ExecuteScalar().ToString().Replace(" ","");
                if(password == passwordtextbox.Text)
                {
                    Session["New"] = usernametextbox.Text;
                    Response.Write("Password is correct");
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["username"].Value = usernametextbox.Text;                        
                    }
                    else
                    {
                        Response.Cookies["username"].Value = "";                     
                    }
                    Response.Redirect("Products.aspx");
                }
                else
                {
                    Response.Write("Password is not correct");
                }
            }
            else
            {
                Response.Write("Username is not correct");
            }
            conn.Close();
        }

    }
}