using eCommerceWebsiteExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Data
{
    public class ProductDb
    {
        /// <summary>
        /// Returns the total count of products
        /// </summary>
        /// <param name="_context">Database context to use</param>
        public static async Task<int> GetTotalProductsAsync(ProductContext _context)
        {
            return await(from p in _context.Products // get the amount of products
                  select p).CountAsync();
        }

        /// <summary>
        /// Get specified amount of products in a page
        /// </summary>
        /// <param name="_context">Database context to use</param>
        /// <param name="pageSize">The number of products per page</param>
        /// <param name="pageNum">Page of products to return</param>
        /// <returns></returns>
        public static async Task<List<Product>> GetProductsAsync(ProductContext _context, int pageSize, int pageNum)
        {
            // Get 3 products from database
            List<Product> products =
                await (from p in _context.Products
                       orderby p.Title ascending
                       select p)
                       .Skip(pageSize * (pageNum - 1)) // skip first
                       .Take(pageSize) // take second
                       .ToListAsync(); // gets all products from the database
            return products;
        }

        public static async Task<Product> AddProductAsync(ProductContext _context, Product p)
        {
            // Add to DB
            _context.Products.Add(p);
            // goes into the database
            await _context.SaveChangesAsync(); // executes

            return p;
        }
    }
}