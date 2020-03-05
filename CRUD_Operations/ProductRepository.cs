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
    }
}
