using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TropicalServer.UI
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString);
                con.Open();
                SqlDataAdapter query = new SqlDataAdapter("Select * From dbo.[tblItemType]", con);
                SqlDataAdapter queryTblItem = new SqlDataAdapter("Select ItemType, ItemNumber, ItemDescription, PrePrice From dbo.[tblItem]", con);
                DataSet ds = new DataSet();
                DataSet dsTblItem = new DataSet();

                query.Fill(ds);
                queryTblItem.Fill(dsTblItem);
                con.Close();

                Cache["products"] = ds;
                Cache["productionItem"] = dsTblItem;
                Repeater1.DataSource = Cache["products"];
                Repeater1.DataBind();

                if (Session["New"] != null)
                {
                    Label1.Text += Session["New"].ToString();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            Label2.Text = "Displaying Page " + (GridView1.PageIndex + 1).ToString();
        }

        protected void productCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int i = int.Parse(e.CommandArgument.ToString());
            DataSet filteredSet = new DataSet();
            filteredSet = (DataSet)Cache["productionItem"];
            DataView dataView = filteredSet.Tables[0].DefaultView;
            dataView.RowFilter = "ItemType =" + i;

            GridView1.DataSource = dataView ;
            GridView1.DataBind();
        }
    }
}