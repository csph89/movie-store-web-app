using MovieStore2019.Models;
using MovieStore2019.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStore2019.Controllers
{
    public class CustomersController : Controller
    {

        //We declare a private field of type ApplicationDbContext in order to have access to the database.
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //Me thn Include() tou leme na symperilavei se kathe eggrafh kai to pedio MembershipType vash tou MembershipTypeId kathe eggrafhs.
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        // GET: Customers/Details/id
        public ActionResult Details(int? id) //In order to show a customer at any case we can give a default value if an id parameter is not provided --> (int id = 1)
        {
            //Vriskei ton customer me auto to id(an uparxei)
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //An den uparxei tote epistrefei ena HttpNotFoundResult mesw ths helper method HttpNotFound()
            if (customer == null)
                return HttpNotFound();
            //An uparxei stelnei ton customer auton sto Details.cshtml view
            return View(customer);
        }

        // GET: The empty form to create a new customer.
        public ActionResult Create()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer() // This will make a new object and the properties of it will set to default values.
            };
            return View("CustomerForm", viewModel);
        }

        // GET: The form of the customer whose Id is equal to id.
        public ActionResult Edit(int id)
        {
            //Here first we need to get the customer with this id from the database.
            var customer = _context.Customers.SingleOrDefault(c => id == c.Id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
            //Sthn ousia provallw th forma sumplhrwmenh me ta stoixeia tou sugkekrimenou customer, me skopo na ta allaksw.
        }

        // POST: Create a new Customer or Update an existing one.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid) // If is not valid render the same View plus the validation error messages.
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0) //An to Id einai 0 tote shmainei oti den exei parei timh to Id epomenws den exei ginei eggrafh sth vash mas.
            {
                //If this is a new customer we should add it to the database.
                _context.Customers.Add(customer);
            }
            else
            {
                //If this is an existing customer so we should update it.
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); //We first find the customer object in the database.
                //We have to add @Html.HiddenFor(m => m.Customer.Id) to include the Id property in the form in order to use it here as form data. 

                //We manually update each property of the existing customer with new values came from the form data.
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                //Microsoft Doc - Model Binding: If binding fails, MVC doesn't throw an error. Every action which accepts user input 
                //should check the "ModelState.IsValid" property.
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}

