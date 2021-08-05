﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Models
{
    /// <summary>
    /// A salable product
    /// </summary>
    public class Product
    {
        [Key]   // PRIMARY KEY in database
        public int ProductID { get; set; }

        /// <summary>
        /// The consumer facing name of the product
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The retail price as US currency
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Category Ex: Electronics, Clothing, etc..
        /// </summary>
        public string Category { get; set; }
    }
}