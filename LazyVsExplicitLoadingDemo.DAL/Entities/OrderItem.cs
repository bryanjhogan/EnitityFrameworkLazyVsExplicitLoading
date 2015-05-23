namespace LazyVsExplicitLoadingDemo.DAL.Entities
{
    public class OrderItem
    {
        #region Private Fields

        #endregion

        #region Constructors

        #endregion

        #region Public Properties

        public int OrderItemID { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        #endregion


        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
