using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Service;
using System.Reflection.Metadata.Ecma335;

namespace ProductsApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Get all the Products
            //var products = _productService.GetAllProducts();
            //return View();
            return Content("Product Controller is working");
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
