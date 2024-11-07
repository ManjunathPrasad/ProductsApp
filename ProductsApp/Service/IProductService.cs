using ProductsApp.Models;

namespace ProductsApp.Service
{
    public interface IProductService
    {
        Product CreateProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}