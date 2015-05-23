using System.Data.Entity;
using LazyVsExplicitLoadingDemo.DAL.Entities;

namespace LazyVsExplicitLoadingDemo.DAL
{
    public class LazyVsExplicityLoadingDemoContext : DbContext
    {
        #region Constructors

        public LazyVsExplicityLoadingDemoContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LazyVsExplicityLoadingDemoContext>());
        }

        #endregion

        #region Public Properties

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        #endregion

    }
}
