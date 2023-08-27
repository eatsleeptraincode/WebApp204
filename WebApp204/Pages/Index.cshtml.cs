using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp204.Models;
using WebApp204.Services;

namespace WebApp204.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService service;
        public List<Product> Products = new List<Product>();

        public IndexModel(ILogger<IndexModel> logger, IProductService service)
        {
            _logger = logger;
            this.service = service;
           
        }

        public void OnGet()
        {
            Products = service.GetProducts();

        }
    }
}