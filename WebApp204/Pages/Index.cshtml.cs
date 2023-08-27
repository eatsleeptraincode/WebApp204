using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp204.Models;
using WebApp204.Services;

namespace WebApp204.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductService service;
        public List<Product> Products = new List<Product>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            service = new ProductService();
        }

        public void OnGet()
        {
            //Products = service.GetProducts();

        }
    }
}