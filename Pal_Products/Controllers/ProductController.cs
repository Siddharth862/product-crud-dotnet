using Microsoft.AspNetCore.Mvc;
using Dal_Product;
using Pal_Products.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pal_Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            var prodViewModels = products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Qty = p.Qty,
                EmailAddress = p.EmailAddress
            }).ToList();
            return View(prodViewModels);
        }

        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var prod = _productService.GetProductById(id);
            if (prod == null)
            {
                return NotFound();
            }
            var pModel = new ProductViewModel
            {
                ProductId = prod.ProductId,
                Name = prod.Name,
                Price = prod.Price,
                Qty = prod.Qty,
                EmailAddress = prod.EmailAddress
            };
            return View(pModel);
        }

        // GET: Product/AddProduct
        public IActionResult AddProduct()
        {
            return View();
        }

        // POST: Product/AddProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(ProductViewModel pModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pModel);
            }
            var prod = new Product
            {
                Name = pModel.Name,
                Price = pModel.Price,
                Qty = pModel.Qty,
                EmailAddress = pModel.EmailAddress
            };
            _productService.AddProduct(prod);
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int id)
        {
            var prod = _productService.GetProductById(id);
            if (prod == null)
            {
                return NotFound();
            }
            var pModel = new ProductViewModel
            {
                ProductId = prod.ProductId,
                Name = prod.Name,
                Price = prod.Price,
                Qty = prod.Qty,
                EmailAddress = prod.EmailAddress
            };
            return View(pModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductViewModel pModel)
        {
            if (id != pModel.ProductId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductId = pModel.ProductId,
                    Name = pModel.Name,
                    Price = pModel.Price,
                    Qty = pModel.Qty,
                    EmailAddress = pModel.EmailAddress
                };
                _productService.UpdateProduct(product, id);
                return RedirectToAction(nameof(Index));
            }
            return View(pModel);
        }

        // GET: Product/DeleteProduct/5
        public IActionResult DeleteProduct(int id)
        {
            var prod = _productService.GetProductById(id);
            if (prod == null)
            {
                return NotFound();
            }
            var pModel = new ProductViewModel
            {
                ProductId = prod.ProductId,
                Name = prod.Name,
                Price = prod.Price,
                Qty = prod.Qty,
                EmailAddress = prod.EmailAddress
            };
            return View(pModel);
        }

        // POST: Product/DeleteProductConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProductConfirmed(int ProductId)
        {
            _productService.DeleteProduct(ProductId);
            return RedirectToAction(nameof(Index));
        }
    }
}