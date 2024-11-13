using ProductsApp.Models;

namespace ProductsApp.Service
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();
        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "iPhone", Price = 123000.99M },
                new Product { Id = 2, Name = "Galaxy", Price = 110000.99M },
                new Product { Id = 3, Name = "Huawei", Price = 101000.99M }
            };
        }
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
