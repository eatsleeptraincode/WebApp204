using Microsoft.Data.SqlClient;
using WebApp204.Models;

namespace WebApp204.Services
{
    public class ProductService
    {
        private static string databaseName = "";
        private static string databaseUser = "";
        private static string databasePassword = "";
        private static string databaseServer = "";

        private SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder  builder = new SqlConnectionStringBuilder();
            builder.DataSource = databaseServer;
            builder.UserID = databaseUser;
            builder.Password = databasePassword;
            builder.InitialCatalog = databaseName;
            return new SqlConnection( builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            using var connection = GetConnection();
            try
            {
                var products = new List<Product>();
                string statement = "SELECT [ProductID],[ProductName],[Quantity]FROM [dbo].[Products]";
                connection.Open();

                var command = new SqlCommand(statement, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product()
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Quantity = reader.GetInt32(2)
                        };
                        products.Add(product);
                    }
                }
                return products;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
