using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Data.Entity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class CustomersController : Controller
    {
       private ApplicationDbContext _context; // we need dbcontext to access the database
        public CustomersController()//initialize dbcontext in constructor
        {
            _context = new ApplicationDbContext();

        }
        //dbcontext is the disposable object so we need to properly dispose it
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();//ToList();//when this line is executed entity framwork in not going to query to DB (differed execution)
                                                        //but after Tolist() query is executed fromu this line
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel 
                {
                    Customer=new Customer(),
                MembershipTypes=membershipTypes
                };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)//Model binding
        {   
                                                       //MVC framework will automatically map request data to the obj viewModel
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customer.Id == 0)
                //adding customer to the database
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubsribedToNewsletter = customer.IsSubsribedToNewsletter;
            }
            _context.SaveChanges();//dbcontext goes to all modification and SQL is generated and changes in save

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            //model behind this view is CustomerFormViewModel
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);

        }

      /* private IEnumerable<Customer> GetCustomers()  //hardcoded method for accessing data
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }*/
    }
}