using eCommerceWebsiteExample.Data;
using eCommerceWebsiteExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Controllers
{
    /// <summary>
    /// Cart controller for the purchasing of products
    /// </summary>
    public class CartController : Controller
    {
        // fields
        private readonly ProductContext _context;
        private readonly IHttpContextAccessor _httpContext;

        // constructor injection: inject services DbContext
        public CartController(ProductContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        /// <summary>
        /// Adds a product to the shopping cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Add(int id, string prevUrl) // Id of product to add
        {
            Product p = await ProductDb.GetProductAsync(_context, id);

            CookieHelper.AddProductToCart(_httpContext, p);

            TempData["Message"] = p.Title + " added succesfully!";
            
            // Redirect back to previous page
            return Redirect(prevUrl);
        }

        /// <summary>
        /// Display list of items added to the cart
        /// </summary>
        /// <returns></returns>
        public IActionResult Summary()
        {
            List<Product> cartProducts = CookieHelper.GetCartProducts(_httpContext);
            return View(cartProducts);
        }
    }
}