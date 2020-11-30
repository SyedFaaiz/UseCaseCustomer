using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UseCaseCustomer.Models;

namespace UseCaseCustomer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult HomePage(Customer customer)
        {
            if (!ModelState.IsValid)
                return View();

            if (Repository.Customers.Any(p => p.Email == customer.Email))
            {
                return Content("A user with this email address already exists. Do you want to login?");
                
            }


            Repository.AddCustomer(customer);
            return View("Customer", customer);
        }


        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            return View(Repository.Customers);
        }

    }
}
