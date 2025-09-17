using Dal_Product;
using System;
namespace Dal_Product.Services
{
    public interface IProductService
    {
        int AddProduct(Product product);
        int UpdateProduct(Product product, int id);
        int DeleteProduct(int id);
        Product GetProductById(int id);
        List<Product> GetProducts();
    }
}

