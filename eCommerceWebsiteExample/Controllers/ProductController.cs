using eCommerceWebsiteExample.Data;
using eCommerceWebsiteExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context; // not accessible anywhere else

        // constructor injection: inject services DbContext
        public ProductController(ProductContext context)
        {
            _context = context;    
        }
        /// <summary>
        /// Displays a view that list all products
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Get all products from database
            List<Product> products = _context.Products.ToList(); // gets all products from the database

            // Send list of all products to view and display
            return View(products); // takes an object to display
        }
    }
}
