namespace ProductManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PMS : DbContext
    {
        public PMS()
            : base("name=PMS")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_pass)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_price)
                .HasPrecision(18, 0);
        }
    }
}
