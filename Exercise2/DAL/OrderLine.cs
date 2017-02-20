namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderLine
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
