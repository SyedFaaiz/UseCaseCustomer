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
        public string _Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string _Password { get; set; }

        [Required(ErrorMessage = "Please enter your city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your street address")]
        public string Street { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your postal code")]
        public string PostalCode { get; set; }
    }
}
