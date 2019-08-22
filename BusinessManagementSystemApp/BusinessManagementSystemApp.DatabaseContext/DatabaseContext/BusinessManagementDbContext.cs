using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.DatabaseContext.DatabaseContext
{
    public class BusinessManagementDbContext:DbContext
    {
        public BusinessManagementDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CustomerModel> CustomerModels { set; get; }
        public DbSet<Sale> Sales { set; get; }
        public DbSet<SalesDetails> SalesDetails { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<PurchaseDetails> PurchaseDetails { set; get; }
        public DbSet<Purchase> Purchases { set; get; }


    }
}
