using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace TropicalServer
{
    public class Order
    {
        public int orderid { get; set; }
        public string tracking { get; set; }
        public string orderdate { get; set; }
        public int custid { get; set; }
        public string address { get; set; }
        public string custname { get; set; }
        public int route { get; set; }
    }
    public class OrderDataLayer
    {
        public static List<Order> GetAllOrder()
        {
            List<Order> listOrder = new List<Order>();
            string CS = ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from order_table", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Order order = new Order();
                    order.orderid = Convert.ToInt32(rdr["OrderID"]);
                    order.tracking = rdr["Tracking"].ToString();
                    order.orderdate = rdr["OrderDate"].ToString();
                    order.custid = Convert.ToInt32(rdr["Customer_ID"]);
                    order.address = rdr["Address"].ToString();
                    order.custname = rdr["Customer_Name"].ToString();
                    order.route = Convert.ToInt32(rdr["Route"]);

                    listOrder.Add(order);
                }
            }
            return listOrder;
        }


        public static void DeleteOrder(int OrderId)
        {
            string CS = ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Delete from order_table where OrderId=@OrderId", con);
                SqlParameter param = new SqlParameter("@OrderId", OrderId);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void UpdateOrder(int OrderId, string tracking, string orderdate, int custid, string address, string custname, int route)
        {
            string CS = ConfigurationManager.ConnectionStrings["TropicalServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Update order_table SET OrderDate=@OrderDate where OrderID=@OrderID";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramOrderId = new SqlParameter("@OrderID", OrderId);
                cmd.Parameters.Add(paramOrderId);
                SqlParameter paramOrderDate = new SqlParameter("@OrderDate", orderdate);
                cmd.Parameters.Add(paramOrderDate);
                con.Open();               
                cmd.ExecuteNonQuery();
            }
        }
    }
}