using Microsoft.AspNetCore.Mvc;
using Shopping.API.Model;
using Shopping.API.Data;
namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductContext.products;
        }
    }
}
