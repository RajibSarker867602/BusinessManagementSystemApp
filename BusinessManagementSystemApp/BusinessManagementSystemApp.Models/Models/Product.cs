using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BusinessManagementSystemApp.Models.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 3)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal CurrentMRP { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public DateTime Date { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
        [NotMapped]
        public List<SalesDetails> SalesSummary { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public IEnumerable<Category> CategoryList { get; set; }

    }
}