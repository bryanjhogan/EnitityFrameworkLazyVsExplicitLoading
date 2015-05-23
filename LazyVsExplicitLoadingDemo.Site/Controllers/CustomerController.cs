using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LazyVsExplicitLoadingDemo.DAL;

namespace LazyVsExplicitLoadingDemo.Site.Controllers
{
    public class CustomerController : Controller
    {
        private LazyVsExplicityLoadingDemoContext db = new LazyVsExplicityLoadingDemoContext();

        public ActionResult IndexLazy()
        {
            return View("Index", db.Customers.ToList());
        }


        public ActionResult IndexExplicit()
        {
            db.Configuration.LazyLoadingEnabled = false; 

            var customers = db.Customers.ToList();
            foreach (var customer in customers)
            {
                db.Entry(customer).Collection(c => c.Orders).Query().Take(1).Load();
            }
            return View("Index",customers);
        }
    }
}