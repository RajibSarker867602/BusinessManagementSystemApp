using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystemApp.Models;

namespace BusinessManagementSystemApp.BLL.Manager
{
    public class ProductManager
    {
        StockRepository _stockRepository = new StockRepository();
        ProductRepository _productRepository = new ProductRepository();

        public bool SaveProduct(Product product)
        {
            return _productRepository.SaveProduct(product);
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public List<Product> SearchProducts(ProductViewModel productViewModel)
        {
            return _productRepository.SearchProducts(productViewModel);
        }
        public Product GetProductById(Product product)
        {
            return _productRepository.GetProductById(product);
        }
        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }
        public bool IsExistProduct(ProductViewModel productViewModel)
        {
            return _productRepository.IsExistProduct(productViewModel);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetByID(int ProductId)
        {
            return _productRepository.GetByID(ProductId);
        }
        public List<Product> GetByCategory(int CategoryId)
        {
            return _productRepository.GetByCategory(CategoryId);

        }
        public List<Product> GetProducts(Product product)
        {
            return _productRepository.GetProducts(product);
        }

        public PurchaseDetails PurchaseDetails(Product product, DateTime startDate, DateTime endDate)
        {
            return _stockRepository.PurchaseDetails(product, startDate, endDate);
        }



    }
}