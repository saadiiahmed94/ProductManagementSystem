namespace ProductManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchase")]
    public partial class Purchase
    {
        [Key]
        public int purchase_id { get; set; }

        public int? product_id { get; set; }

        public int? customer_id { get; set; }

        public DateTime? purchase_date { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
