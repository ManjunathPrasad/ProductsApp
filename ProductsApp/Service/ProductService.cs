using ProductsApp.Models;

namespace ProductsApp.Service
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();
        public IEnumerable<Product> GetAllProducts() => _products;
        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product CreateProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }
    }
}
