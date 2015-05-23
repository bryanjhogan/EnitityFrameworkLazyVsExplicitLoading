using System;
using System.Collections.Generic;

namespace LazyVsExplicitLoadingDemo.DAL.Entities
{
    public class Order
    {
        #region Private Fields

        #endregion

        #region Public Properties

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Comment { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
