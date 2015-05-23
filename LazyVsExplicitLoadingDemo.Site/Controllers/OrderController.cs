using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LazyVsExplicitLoadingDemo.DAL;

namespace LazyVsExplicitLoadingDemo.Site.Controllers
{
    public class OrderController : Controller
    {
        private LazyVsExplicityLoadingDemoContext db = new LazyVsExplicityLoadingDemoContext();

        public ActionResult DetailsLazy(int customerID)
        {
            var customer = db.Customers.Find(customerID);
            return View("Details", customer.Orders.FirstOrDefault());
        }

        public ActionResult DetailsExplicit(int customerID)
        {
            db.Configuration.LazyLoadingEnabled = false; 

            var customer = db.Customers.Find(customerID);

            //get the first order
            db.Entry(customer).Collection(c => c.Orders).Query().Take(1).Load();

            //get the first order item
            db.Entry(customer.Orders.FirstOrDefault()).Collection(o => o.OrderItems).Query().Take(1).Load();

            return View("Details", customer.Orders.FirstOrDefault());
        }
    }
}