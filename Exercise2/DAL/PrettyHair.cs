namespace DAL {
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class PrettyHair : DbContext {
		public PrettyHair()
			: base("name=PrettyHairConn") {
		}

		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<OrderLine> OrderLines { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<ProductType> ProductTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Entity<Customer>()
				.HasMany(e => e.Orders)
				.WithRequired(e => e.Customer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Order>()
				.HasMany(e => e.OrderLines)
				.WithRequired(e => e.Order)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ProductType>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<ProductType>()
				.HasMany(e => e.OrderLines)
				.WithRequired(e => e.ProductType)
				.HasForeignKey(e => e.ProductID)
				.WillCascadeOnDelete(false);
		}
	}
}
