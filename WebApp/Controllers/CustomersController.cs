using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Data.Entity;

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
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();//when this line is executed entity framwork in not going to query to DB (differed execution)
                                                        //but after Tolist() query is executed from this line
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

      /*  private IEnumerable<Customer> GetCustomers()  //hardcoded method for accessing data
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }*/
    }
}