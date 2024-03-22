using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ICE_Task_One.Data;
using ICE_Task_One.Models;

namespace ICE_Task_One.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICE_Task_OneContext _context;

        public AccountController(ICE_Task_OneContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Hash the password and check against the database here
            // For demonstration, password hashing is omitted

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password); // Use password hash comparison in real app

            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid login attempt";
                return View();
            }

            // Here you would typically use SignInManager or similar to sign the user in.
            // For this example, we're skipping that step.
            // Redirect to the Books/Index view after successful login
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string email, string password)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == email);
            if (userExists)
            {
                ViewBag.ErrorMessage = "User already exists.";
                return View();
            }

            // Here, you should hash the password before saving it to the database.
            var user = new User { Email = email, PasswordHash = password };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Optionally, sign the user in automatically after registration
            // Redirect to the login page for now
            return RedirectToAction("Login");
        }
    }
}
