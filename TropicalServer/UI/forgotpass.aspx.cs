using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TropicalServer.UI
{
    public partial class forgotpass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Update_Click(object sender, EventArgs e)
        {            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select LoginID from tblTropicalUser " +
                "where LoginID = '" + usernametextbox.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count.ToString() == "1")
            {
                if (passwordtextbox.Text == newpass.Text)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update tblTropicalUser set Password = '" +
                    newpass.Text + "'where LoginID='" + usernametextbox.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label1.Text = "Successfully updated.";
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Label1.Text = "Same password, please re-type again.";
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}