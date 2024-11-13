using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Service;
using System.Reflection.Metadata.Ecma335;

namespace ProductsApp.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            //Get all the Products
            var products = _productService.GetAllProducts();
    
            if (products == null)
            {
                // Handle the null case, maybe redirect or show an error view.
                return View("Error");  // or a view that handles empty products.
            }
            return View(products);
            //return Content("Product Controller is working");
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            // Get the product by Id
            var product = _productService.GetProductById(id);
            //Handle End Cases
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create1")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
