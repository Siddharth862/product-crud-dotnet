using System.Collections.Generic;
using System.Linq;
using Dal_Product;
using Microsoft.EntityFrameworkCore;

namespace Dal_Product.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }

        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges();
        }

        public int UpdateProduct(Product product, int id)
        {
            var existing = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (existing == null)
                return 0;

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Qty = product.Qty;
            existing.EmailAddress = product.EmailAddress;

            return _context.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return 0;

            _context.Products.Remove(product);
            return _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
