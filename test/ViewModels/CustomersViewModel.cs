using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.Models;

namespace test.ViewModels
{
    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Customer> CustomersDetails { get; set; }
    }
}