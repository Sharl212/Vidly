using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oceans.Models;
using test.Models;
using test.ViewModels;

namespace test.Controllers
{
    public class CustomersController : Controller
    {
        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            Console.WriteLine(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) // if the data didn't pass the validation
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", viewModel); // return the same form but with validation errors
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        // GET: Customers
        [Route("customers")]
        public ViewResult Index()
        {
            var customersList = _context.Customers.Include(c => c.MembershipType).ToList();

            var viewCustomer = new CustomersViewModel
            {
                Customers = customersList
            };

            return View(viewCustomer);
        }

        [Route("customers/edit")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", viewModel);
        }

        public ActionResult Details(int id)
        {
            var customerDetails = _context.MembershipTypes.SingleOrDefault(c => c.Id == id);

            ViewBag.message = customerDetails;
            return View();
        }
    }
}