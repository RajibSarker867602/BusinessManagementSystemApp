using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class ShowStockDetailsController : Controller
    {
        StockManager _stockManager = new StockManager();
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        Product _product = new Product();


        // GET: Stock
        public ActionResult Search()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Search(ProductViewModel productViewModel, DateTime startDate, DateTime endDate)
        {


            _product.ProductName = productViewModel.ProductName;
            _product.CategoryName = productViewModel.CategoryName;
            try
            {
                List<ProductViewModel> products = _productManager.GetProducts(_product).Select(c => new ProductViewModel
                {
                    ProductName = c.ProductName,
                    CategoryName = c.Category.CategoryName,
                    ReorderLevel = c.ReorderLevel,
                    ProductCode = c.ProductCode,
                }).ToList();

                foreach (var product in products)
                {
                    Product pro = new Product();
                    pro.ProductName = product.ProductName;
                    var expireDate = _productManager.PurchaseDetails(pro, startDate, endDate);
                    foreach (var item in products)
                    {
                        if (item.ProductName == pro.ProductName)
                        {
                            item.ExpireDate = expireDate.ExpireDate;
                            TempData["SuccessMessage"] = "Search Successfully";
                        }

                    }
                }
                ViewBag.Products = products;
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Search data not found";
            }



            return View();
        }

    }
}