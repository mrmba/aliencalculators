using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ProductSqlDAL : IProductDAL
    {

        private string SQL_GetProducts = "Select * From products;";
        private string SQL_GetProductDetails = "Select * From products Where product_id = @id;";

        private string connectionString;

        public ProductSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        //get product from database using id
        public Product GetProduct(int id)
        {
            Product productdetails = new Product();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetProductDetails, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        productdetails = GetProductFromReader(reader);                      
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return productdetails;
        }

        //get products from data base and put them into a list as objects
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetProducts, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product thisProduct = GetProductFromReader(reader);
                        products.Add(thisProduct);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return products;
        }

        //covert products from database
        private Product GetProductFromReader(SqlDataReader reader)
        {
            Product convertProduct = new Product();
            convertProduct.ProductId = Convert.ToInt32(reader["product_id"]);
            convertProduct.Name = Convert.ToString(reader["name"]);
            convertProduct.Description = Convert.ToString(reader["description"]);
            convertProduct.Price = Convert.ToDecimal(reader["price"]);
            convertProduct.ImageName = Convert.ToString(reader["image_name"]);

            return convertProduct;
        }
    }
}