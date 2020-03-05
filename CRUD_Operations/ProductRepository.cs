using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CRUD_Operations
{
    class ProductRepository
    {
        public string connString;

        public ProductRepository(string _connectionString)
        {
            connString = _connectionString;
        }
        
        public List<Product> GetProducts()
        {
            //This method should be able to select fields from your MySql server and display them. 
            MySqlConnection conn = new MySqlConnection(connString);
            List<Product> products = new List<Product>();

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Stocklevel, Name, Price, ProductID FROM products;";

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        StockLevel = (string)reader["StockLevel"],
                        Name = (string)reader["Name"],
                        Price = (decimal)reader["Price"],
                        ProductID = (int)reader["ProductID"]
                    };
                    products.Add(product);
                    Console.WriteLine($"{product.ProductID}...{product.Name}...{product.Price}...{product.StockLevel}");
                }
            }
            return products;
        }
        public void CreateProduct(Product prod)
        {
            //This method should be able to insert fields into your MySQL server.
            //Note, if you want to see changes you will need to run GetProducts(); again.
            MySqlConnection conn = new MySqlConnection(connString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products (Name, Price, CategoryID, OnSale) VALUES (@n, @p, @cID, @sale);";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.CategoryID);
                cmd.Parameters.AddWithValue("sale", prod.OnSale);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
