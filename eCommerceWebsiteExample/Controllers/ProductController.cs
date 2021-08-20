using eCommerceWebsiteExample.Data;
using eCommerceWebsiteExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            // Get all products from database
            List<Product> products =
                await (from p in _context.Products 
                       select p).ToListAsync(); // gets all products from the database

            // Send list of all products to view and display
            return View(products); // takes an object to display
        }

        [HttpGet] // link to URL
        public IActionResult Add() // talks to the database
        {
            return View();
        }

        [HttpPost] // after submission
        // anytime there is a database code: use async code
        public async Task<IActionResult> Add(Product p)
        {
            if (ModelState.IsValid)
            {
                // Add to DB
                _context.Products.Add(p);
                // goes into the database
                await _context.SaveChangesAsync(); // executes

                // populate succcess message
                TempData["Message"] = $"{p.Title} was added successfully!";

                // redirect back to catalog page
                return RedirectToAction("Index"); 
            }

            // if not valid return same view with error messages
            return View();
        }

        /// <summary>
        /// Edits a specific product selected
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Get product with corresponding id
            Product p =
            await (from prod in _context.Products
                   where prod.ProductID == id
                   select prod).SingleAsync();
            // This is a method syntax
            //Product p2 =
            //   await _context
            //        .Products
            //        .Where(prod => prod.ProductID == id)
            //        .SingleAsync();

            // pass product to view
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                ViewData["Message"] = "Product updated successfully!";
            }
            return View(p);
        }
    }
}
