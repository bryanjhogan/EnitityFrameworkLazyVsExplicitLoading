using System.Collections.Generic;

namespace LazyVsExplicitLoadingDemo.DAL.Entities
{
    public class Customer
    {
        #region Private Fields

        #endregion

        #region Constructors

        #endregion

        #region Public Properties

        public int CustomerID { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Order> Orders { get; set; } 

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
