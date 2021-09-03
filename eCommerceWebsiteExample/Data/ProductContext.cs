using eCommerceWebsiteExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Data
{
    public class ProductContext : DbContext
    {
        // constructor
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { 
            // default this is empty
        }

        /// <summary>
        /// Creates product table
        /// </summary>
        public DbSet<Product> Products { get; set; } 

        /// <summary>
        /// Creates user accounts table
        /// </summary>
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}