using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LazyVsExplicitLoadingDemo.DAL;
using LazyVsExplicitLoadingDemo.DAL.Entities;

namespace LazyVsExplicitLoadingDemo.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetupDB();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void SetupDB()
        {
            //This is not proper way to seed a database, but it's easy to understand and see
            LazyVsExplicityLoadingDemoContext demoContext = new LazyVsExplicityLoadingDemoContext();
            if (demoContext.Customers.Any())
            {
                return;
            }

            demoContext.Database.ExecuteSqlCommand("DELETE FROM [OrderItems]");
            demoContext.Database.ExecuteSqlCommand("DELETE FROM [Orders]");
            demoContext.Database.ExecuteSqlCommand("DELETE FROM [Customers]");

            var lazySteve = new Customer { Firstname = "Lazy Steve", Lastname = "Smith" };
            var steveOrderOne = new Order { Comment = "Steve's first order", OrderDate = DateTime.Today.AddDays(-5) };
            var steveOrderTwo = new Order { Comment = "Steve's second order", OrderDate = DateTime.Today.AddDays(-4) };
            var steveOrderThree = new Order { Comment = "Steve's third order", OrderDate = DateTime.Today.AddDays(-3) };
            var steveOrderFour = new Order { Comment = "Steve's fourth order", OrderDate = DateTime.Today.AddDays(-2) };

            var steveOrderOneItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Ball", Price = 3.00},
                    new OrderItem() {ItemDescription = "Watch", Price = 32.00},
                    new OrderItem() {ItemDescription = "Book", Price = 12.00},
                    new OrderItem() {ItemDescription = "Glasses", Price = 41.00},
                    new OrderItem() {ItemDescription = "Pen", Price = 4.00},
                    new OrderItem() {ItemDescription = "Chair", Price = 23.00}
                };
            steveOrderOne.OrderItems = steveOrderOneItems;

            var steveOrderTwoItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Laptop", Price = 400.00},
                    new OrderItem() {ItemDescription = "Mouse", Price = 13.00},
                    new OrderItem() {ItemDescription = "Bottle", Price = 1.00},
                    new OrderItem() {ItemDescription = "Stapler", Price = 7.00},
                    new OrderItem() {ItemDescription = "Wires", Price = 2.50}
                };
            steveOrderTwo.OrderItems = steveOrderTwoItems;

            var steveOrderThreeItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Hose", Price = 41.00}
                };
            steveOrderThree.OrderItems = steveOrderThreeItems;

            var steveOrderFourItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Tiles", Price = 22.00}
                };
            steveOrderFour.OrderItems = steveOrderFourItems;

            lazySteve.Orders = new Collection<Order> { steveOrderOne, steveOrderTwo, steveOrderThree, steveOrderFour };

            var james = new Customer { Firstname = "James", Lastname = "Jones" };
            var jamesOrderOne = new Order { Comment = "James' first order", OrderDate = DateTime.Today.AddDays(-4) };
            var jamesOrderTwo = new Order { Comment = "James' second order", OrderDate = DateTime.Today.AddDays(-3) };
            var jamesOrderThree = new Order { Comment = "James' third order", OrderDate = DateTime.Today.AddDays(-2) };
            var jamesOrderFour = new Order { Comment = "James' fourth order", OrderDate = DateTime.Today.AddDays(-1) };


            var jamesOrderOneItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Table", Price = 49.00},
                    new OrderItem() {ItemDescription = "Spoons", Price = 1.99},
                    new OrderItem() {ItemDescription = "Forks", Price = 2.99},
                    new OrderItem() {ItemDescription = "Cups", Price = 5.00},
                    new OrderItem() {ItemDescription = "Plates", Price = 14.00},
                    new OrderItem() {ItemDescription = "Knives", Price = 8.00}
                };
            jamesOrderOne.OrderItems = jamesOrderOneItems;

            var jamesOrderTwoItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Bike", Price = 340.00},
                    new OrderItem() {ItemDescription = "Reflectors", Price = 9.00},
                    new OrderItem() {ItemDescription = "Tool", Price = 10.00},
                    new OrderItem() {ItemDescription = "Tube repair", Price = 4.99},
                    new OrderItem() {ItemDescription = "Lights", Price = 11.00},
                    new OrderItem() {ItemDescription = "Helmet", Price = 27.00}
                };
            jamesOrderTwo.OrderItems = jamesOrderTwoItems;

            var jamesOrderThreeItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Mouse", Price = 14.00},
                    new OrderItem() {ItemDescription = "Keyboard", Price = 29.00},
                };
            jamesOrderThree.OrderItems = jamesOrderThreeItems;

            var jamesOrderFourItems = new List<OrderItem>
                {
                    new OrderItem() {ItemDescription = "Mouse", Price = 14.00},
                    new OrderItem() {ItemDescription = "Keyboard", Price = 29.00},
                };
            jamesOrderFour.OrderItems = jamesOrderFourItems;

            james.Orders = new Collection<Order> { jamesOrderOne, jamesOrderTwo, jamesOrderThree, jamesOrderFour };

            demoContext.Customers.Add(lazySteve);
            demoContext.Customers.Add(james);

            demoContext.SaveChanges();
        }
    }
}