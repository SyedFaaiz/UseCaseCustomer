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

        private static string saveUserInfo;

        private CustomersDatabase _customersDb;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _customersDb = new CustomersDatabase();
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
        /*
   //     [HttpPost]
        public IActionResult HomePage(Customer customer)
        {

           
            if (!ModelState.IsValid)
                return View();

            if (Repository.Customers.Any(p => p.Email == customer.Email))
            {
                saveUserInfo = (customer.Name);
                return View("HomePage");
            }


            
            else
            {
                Repository.AddCustomer(customer);
                return RedirectToAction("Dashboard", customer);
            }
        }
        */
        /*
        public IActionResult Dashboard(Customer user)
        {


            if (Repository.Customers.Any(p => p.Email != user.Email))
            {
                return Content($"Hi {saveUserInfo}, your email doesn't match to the account you signed up for");
            }


            else
            {
                return View("Dashboard", user);
            }
        }
        */

        
                
        public IActionResult HomePage()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult SaveCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return View("Homepage");

            if (customer.Id == null)
                _customersDb.Customers.Add(customer);

            else
            {
                var customerInDb = _customersDb.Customers.Find(customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Email = customer.Email;
                customerInDb.Year = customer.Year;
                customerInDb.Make = customer.Make;
                customerInDb.Model = customer.Model;

            }

            _customersDb.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [Route("home/customers/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var customersToBeDeleted = _customersDb.Customers.Find(id);

            if (customersToBeDeleted == null)
                return NotFound();

            _customersDb.Customers.Remove(customersToBeDeleted);
            _customersDb.SaveChanges();


            return RedirectToAction("CustomerList");
        }


        [Route("home/customers/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var customersToBeEdited = _customersDb.Customers.Find(id);

            if (customersToBeEdited == null)
                return NotFound();




            return View("Homepage", customersToBeEdited);
        }

        public IActionResult CustomerList()
        {
            //  return View(Repository.Customers);
            return View();
        }

    }
}
