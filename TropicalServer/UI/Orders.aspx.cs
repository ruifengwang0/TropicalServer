using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TropicalServer.UI
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }

        void PopulateGridView()
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from order_table", con);
                sda.Fill(dt);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void FillGrid()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString);
            con.Open();
            string query = "select * from order_table";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            PopulateGridView();
        }

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{

        //    //int indexnew = Convert.ToInt32(e.CommandArgument);
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString))
        //    {
        //        con.Open();
        //        string query = "UPDATE order_table SET OrderID = @OrderID, Tracking=@Tracking, OrderDate=@OrderDate," +
        //            "Customer_ID=@Customer_ID, Address=@Address, Customer_Name=@Customer_Name, Route=@Route WHERE OrderID=@OrderID";
                
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        //cmd.Parameters.AddWithValue("@OrderID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));

        //        cmd.Parameters.AddWithValue("@OrderID", Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text.ToString()));
        //        //cmd.Parameters.AddWithValue("@Tracking", (GridView1.Rows[e.RowIndex].FindControl("txtTracking") as TextBox).Text.Trim());
        //        cmd.Parameters.AddWithValue("@Tracking", Convert.ToString(GridView1.Rows[e.RowIndex].Cells[2].Text));
        //        cmd.Parameters.AddWithValue("@OrderDate", (GridView1.Rows[e.RowIndex].Cells[3].Text.ToString()));
        //        cmd.Parameters.AddWithValue("@Customer_ID", (GridView1.Rows[e.RowIndex].Cells[4].Text.ToString()));
        //        cmd.Parameters.AddWithValue("@Address", (GridView1.Rows[e.RowIndex].Cells[5].Text.ToString()));
        //        cmd.Parameters.AddWithValue("@Customer_Name", (GridView1.Rows[e.RowIndex].Cells[6].Text.ToString()));
        //        cmd.Parameters.AddWithValue("@Route", (GridView1.Rows[e.RowIndex].Cells[7].Text.ToString()));
        //        // cmd.Parameters.AddWithValue("@OrderDate", (GridView1.Rows[e.RowIndex].FindControl("txtOrderDate") as TextBox).Text.Trim());
        //        //cmd.Parameters.AddWithValue("@Customer_ID", (GridView1.Rows[e.RowIndex].FindControl("txtCustomer_ID") as TextBox).Text.Trim());
        //        //cmd.Parameters.AddWithValue("@Address", (GridView1.Rows[e.RowIndex].FindControl("txtAddress") as TextBox).Text.Trim());
        //        //cmd.Parameters.AddWithValue("@Customer_Name", (GridView1.Rows[e.RowIndex].FindControl("txtCustomer_Name") as TextBox).Text.Trim());
        //        //cmd.Parameters.AddWithValue("@Route", (GridView1.Rows[e.RowIndex].FindControl("txtRoute") as TextBox).Text.Trim());
        //        cmd.ExecuteNonQuery();
        //        GridView1.EditIndex = -1;
        //        PopulateGridView();
        //    }
        //}

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString))
            {
                con.Open();
                string query = "UPDATE order_table SET OrderID = @OrderID, Tracking=@Tracking, OrderDate=@OrderDate," +
                    "Customer_ID=@Customer_ID, Address=@Address, Customer_Name=@Customer_Name, Route=@Route WHERE OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OrderID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                cmd.Parameters.AddWithValue("@Tracking", (GridView1.Rows[e.RowIndex].FindControl("txtTracking") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@OrderDate", (GridView1.Rows[e.RowIndex].FindControl("txtOrderDate") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@Customer_ID", (GridView1.Rows[e.RowIndex].FindControl("txtCustomer_ID") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@Address", (GridView1.Rows[e.RowIndex].FindControl("txtAddress") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@Customer_Name", (GridView1.Rows[e.RowIndex].FindControl("txtCustomer_Name") as TextBox).Text.Trim());
                cmd.Parameters.AddWithValue("@Route", (GridView1.Rows[e.RowIndex].FindControl("txtRoute") as TextBox).Text.Trim());
                cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                PopulateGridView();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString))
            {
                con.Open();
                string query = "DELETE FROM order_table WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OrderID", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                cmd.ExecuteNonQuery();
                PopulateGridView();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
                {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString))
            {
                con.Open();
                DataTable dt = new DataTable();
                string query = "select * from order_table";

                query = filter1(query);
                query = filter2(query);
                query = filter3(query);
                //query = filter4(query);
                //query = filter(query);
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(com);

                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString))
            {
                con.Open();
                DataTable dt = new DataTable();
                string query = "select * from order_table";

                //query = filter1(query);
                //query = filter2(query);
                //query = filter3(query);
                query = filter44(query);
                //query = filter(query);
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(com);

                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View")
            {
                int index1 = Convert.ToInt32(e.CommandArgument);
                //GridViewRow Row1 = (GridViewRow)GridView1.Rows[index1];
                String tracking = GridView1.Rows[index1].Cells[2].Text;
                String orderdate = GridView1.Rows[index1].Cells[3].Text;
                String custid = GridView1.Rows[index1].Cells[4].Text;
                String address = GridView1.Rows[index1].Cells[5].Text;
                String custname = GridView1.Rows[index1].Cells[6].Text;
                String route = GridView1.Rows[index1].Cells[7].Text;
                //String tracking = (Row1.FindControl("Tracking") as Label).Text;
                //String orderdate = (Row1.FindControl("OrderDate") as Label).Text;
                //String custid = (Row1.FindControl("Customer_ID") as Label).Text;
                //String address = (Row1.FindControl("Address") as Label).Text;
                //String custname = (Row1.FindControl("Customer_Name") as Label).Text;
                //String route = (Row1.FindControl("Route") as Label).Text;
                Label31.Text = tracking;
                Label32.Text = orderdate;
                Label33.Text = custid;
                Label34.Text = address;
                Label35.Text = custname;
                Label36.Text = route;
                ModalPopupExtender1.Show();
            }
        }
        protected string filter44(string query)
        {
            if (DropDownList4.SelectedValue == "Nii")
            {
                query += " where Customer_Name='Nii'";
            }
            else if (DropDownList4.SelectedValue == "Anupam")
            {
                query += " where Customer_Name='Anupam'";
            }
            else if (DropDownList4.SelectedValue == "Hitesh")
            {
                query += " where Customer_Name='Hitesh'";
            }
            else if (DropDownList4.SelectedValue == "Chee")
            {
                query += " where Customer_Name='Chee'";
            }
            else if (DropDownList4.SelectedValue == "Andy")
            {
                query += " where Customer_Name='Andy'";
            }
            else
            {

            }
            return query;
        }
        protected string filter1(string query)
            {
                if (DropDownList1.SelectedValue == "Today")
                {
                    query += " where OrderDate > DATEADD(DAY, -1, GETDATE())";
                }
                if (DropDownList1.SelectedValue == "Last 7 Days")
                {
                    query += " where OrderDate > DATEADD(DAY,-7,GETDATE())";
                }
                if (DropDownList1.SelectedValue == "Last 1 Month")
                {
                    query += " where OrderDate > DATEADD(MONTH,-1,GETDATE())";
                }
                if (DropDownList1.SelectedValue == "Last 6 Months")
                {
                    query += " where OrderDate > DATEADD(MONTH,-6,GETDATE())";
                }
                else
                {

                }
                return query;
            }
            protected string filter2(string query)
            {
                if (DropDownList1.SelectedValue != "") 
                {
                    if (TextBox1.Text != "")
                    {
                        query += " and Customer_ID='" + TextBox1.Text + "'";
                    }
                    else
                    {

                    }

                }
                else
                {
                    if (TextBox1.Text != "")
                    {
                        query += " where Customer_ID='" + TextBox1.Text + "'";
                    }
                    else
                    {

                    }
                }
                return query;
            }
            protected string filter3(string query)
            {
                //empty filter
                if (DropDownList1.SelectedValue == "" && TextBox1.Text == "" && TextBox2.Text == "")
                {

                }
                //at least one filter
                else
                {
                    //third filter
                    if (DropDownList1.SelectedValue == "" && TextBox1.Text == "")
                    {
                        query += " where Customer_Name='" + TextBox2.Text + "'";
                    }
                    //(first or second) and third filter
                    else
                    {
                        //first and third filter
                        if (TextBox2.Text == "")
                        {

                        }
                        //all filter 
                        else
                        {
                            query += " and Customer_Name='" + TextBox2.Text + "'";
                        }                  
                    }
                }
                return query;
            }
            protected string filter4(string query)
            {
                //no filter/empty
                if (DropDownList1.SelectedValue=="" && TextBox1.Text == "" && TextBox2.Text=="" && DropDownList4.SelectedValue == "")
                {

                }
                //at least one filter
                else
                {
                    //only forth filter
                    if (DropDownList1.SelectedValue == "" && TextBox1.Text == "" && TextBox2.Text == "")
                    {
                        query += " where Customer_Name ='" + DropDownList4.SelectedValue + "'";
                    }
                    //at least two filter
                    else
                    {
                        query += " and Customer_Name ='" + DropDownList4.SelectedValue + "'";
                    }
                }
                return query;
            }
    }
}


