using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel() 
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=NORTHWND; Integrated Security=True");
            cmd = con.CreateCommand();
        }
        public List<Product> GetProducts() 
        {
            try
            {
                cmd.CommandText = "SELECT P.ProductID, P.ProductName, P.CategoryID, C.CategoryName, P.SupplierID, S.CompanyName, S.ContactName, P.UnitsInStock, P.ReorderLevel, P.Discontinued, P.UnitPrice FROM Products AS P JOIN Categories AS C ON P.CategoryID = C.CategoryID JOIN Suppliers AS S ON P.SupplierID = S.SupplierID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    if (!reader.IsDBNull(2)) 
                    {
                        p.CategoryID = reader.GetInt32(2);
                        p.Category = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        p.SupplierID = reader.GetInt32(4);
                        p.CompanyName = reader.GetString(5);
                        p.ContactName = reader.GetString(6);
                    }
                    p.UnitsInStock = reader.GetInt16(7);
                    p.ReorderLevel = reader.GetInt16(8);
                    p.IsContinued = reader.GetBoolean(9);
                    p.UnitPrice = reader.GetDecimal(10);
                    products.Add(p);
                }
                return products;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
