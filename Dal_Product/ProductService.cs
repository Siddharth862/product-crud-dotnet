using Dal_Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Product
{
    public class ProductService
    {
        // 1. Change constructor to use Dependency Injection
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }

        //Add product
        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges();
        }

        //Update Product
        public int UpdateProduct(Product product, int pid)
        {
            Product prod = _context.Products.Find(pid);
            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.Qty = product.Qty;
                prod.EmailAddress = product.EmailAddress;
            }
            return _context.SaveChanges();
        }

        //Delete Product
        public int DeleteProduct(int pid)
        {
            Product prod = _context.Products.Find(pid);
            if (prod != null)
            {
                _context.Products.Remove(prod);
            }
            return _context.SaveChanges();
        }

        //Get product by ID (standardized naming to ById)
        public Product GetProductById(int pid)
        {
            return _context.Products.Find(pid);
        }

        // 2. Kept the correct method name and implemented it
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}