using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ProductDBContext() : base()
        {
            Application_Start();
        }

        //public ProductContext() : base("DefaultConnection")
        //{
        //    OnModelCreating(new DbModelBuilder());
        //    
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        static void Application_Start()
        {
            Database.SetInitializer(new DbInitializer());
        }

    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ProductDBContext>
    {

    }

}
