using eCommerceWebsiteExample.Data;
using eCommerceWebsiteExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Controllers
{
    public class UserController : Controller
    {
        // field
        private readonly ProductContext _context;
        // constructor
        public UserController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                // map data to user account instance
                UserAccount acc = new UserAccount()
                {
                    DateOfBirth = reg.DateOfBirth,
                    Email = reg.Email,
                    Password = reg.Password,
                    Username = reg.Username
                };
                // add to database
                _context.UserAccounts.Add(acc);
                // query to database
                await _context.SaveChangesAsync();
                // after it is saved redirect to home page
                return RedirectToAction("Index", "Home");
            }

            return View(reg);
        }
    }
}
