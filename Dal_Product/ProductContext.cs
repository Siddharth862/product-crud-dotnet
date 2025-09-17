using Dal_Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Dal_Product
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        // The incorrect 'Product' property has been removed.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ProductDb;Integrated Security=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        // The incorrect, custom SaveChanges() method has been removed.
        // The application will now use the real, working SaveChanges() from the base DbContext.
    }
}