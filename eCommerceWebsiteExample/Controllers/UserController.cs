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

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            // validate model
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Query Syntax
            //UserAccount account =
            //    await (from u in _context.UserAccounts
            //           where (u.Username == model.UsernameOrEmail
            //           || u.Email == model.UsernameOrEmail)
            //           && u.Password == model.Password
            //           select u).SingleOrDefaultAsync();
            // Method Syntax

            UserAccount account = await _context.UserAccounts
                    .Where(userAcc => (userAcc.Username == model.UsernameOrEmail ||
                            userAcc.Email == model.UsernameOrEmail) &&
                            userAcc.Password == model.Password)
                    .SingleOrDefaultAsync();
                     
            if (account == null)
            {
                // Credentials did not match

                // Custom error message
                ModelState.AddModelError(String.Empty, "Credentials were not found.");

                return View(model);
            }

            // Log user into website

            return RedirectToAction("Index", "Home");
        }
    }
}
