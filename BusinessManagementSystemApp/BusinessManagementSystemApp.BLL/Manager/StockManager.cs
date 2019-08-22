using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystemApp.Repository.Repository;
using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Models;


namespace BusinessManagementSystemApp.BLL.Manager
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();

        public List<Product> GetAll()
        {
            return _stockRepository.GetAll();
        }

    }
}