using Microsoft.Data.SqlClient;
using WebApp204.Models;

namespace WebApp204.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }

    public class ProductService : IProductService
    {
        private readonly IConfiguration config;

        public ProductService(IConfiguration config)
        {
            this.config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(config.GetConnectionString("SqlConnection"));
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
