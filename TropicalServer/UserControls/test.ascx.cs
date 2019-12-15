using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TropicalServer
{
    public partial class test : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["username"] != null)
                {
                    TestInput.Text = Request.Cookies["username"].Value;
                }
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString);
            conn.Open();
            string checkuser = "Select count(*) from tblTropicalUser where LoginID= '" + TestInput.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (temp == 1)
            {
                Session["New"] = TestInput.Text;
                //Response.Write("Password is correct");
                Response.Redirect("Products.aspx");
            }
            else
            {
                Response.Write("Invalid username");
            }
        }
    }
}