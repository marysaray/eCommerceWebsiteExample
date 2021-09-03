using eCommerceWebsiteExample.Data;
using eCommerceWebsiteExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceWebsiteExample.Controllers
{
    /// <summary>
    /// The user controller for the website
    /// </summary>
    public class UserController : Controller
    {
        // field
        private readonly ProductContext _context; // not accessible anywhere else

        // constructor injection: inject services DbContext
        public UserController(ProductContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The user registration page URL link
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Add registration after submission
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {
            if (ModelState.IsValid)
            {
                // Check if username/email is in use!
                bool isEmailTaken = await (from account in _context.UserAccounts
                                     where account.Email == reg.Email
                                     select account).AnyAsync();

                // if so, add custom error and send back to view
                if (isEmailTaken)
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Email), "Email is already subscribed.");
                }

                bool isUsernameTaken = await (from account in _context.UserAccounts
                                              where account.Username == reg.Username
                                              select account).AnyAsync();
                if (isUsernameTaken)
                {
                    ModelState.AddModelError(nameof(RegisterViewModel.Username), "Username is already subscribed.");
                }

                if (isEmailTaken || isUsernameTaken)
                {
                    return View(reg);
                }

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

                LogUserIn(acc.UserId);

                // after it is saved redirect to home page
                return RedirectToAction("Index", "Home");
            }

            return View(reg);
        }

        /// <summary>
        /// The log in page for the user URL link
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SignIn()
        {
            // Check if user already logged in
            if (HttpContext.Session.GetInt32("UserId").HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        /// <summary>
        /// Validating user's credentials
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

            LogUserIn(account.UserId);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Log user into the website
        /// </summary>
        /// <param name="accountId"></param>
        private void LogUserIn(int accountId)
        {
            // Log user into website
            HttpContext.Session.SetInt32("UserId", accountId);
        }

        /// <summary>
        /// Destroy session after logging out
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            // Destroy the session
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}