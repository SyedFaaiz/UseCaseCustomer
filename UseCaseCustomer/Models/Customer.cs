using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UseCaseCustomer.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your street address")]
        public string Street { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter the year of your vehicle")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter your vehicle's make")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Please enter your vehicle's model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter your vehicle's VIN")]
        public string VIN { get; set; }
    }
}
