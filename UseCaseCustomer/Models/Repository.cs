using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCaseCustomer.Models
{
    public class Repository
    {

        private static List<Customer> _customers;

        static Repository()
        {
            _customers = new List<Customer>();

        }

        public static void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public static IEnumerable<Customer> Customers => _customers;
    }
}
