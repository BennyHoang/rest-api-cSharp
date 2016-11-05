using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Http;
using WebApp.Models;
using static WebApp.Models.productORMDataContext;

namespace WebApp.Controllers
{
    public class ProductsController : ApiController
    {
        /*
        Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 13.75M },
        };
        */
        


        public IEnumerable<tblProduct> GetAllProducts()
        {
            using (productORMDataContext productOrm = new productORMDataContext())
            {
                List<tblProduct> productList = (from tblProduct in productOrm.tblProducts
                    select tblProduct).ToList();
                return productList;
            }

           
        }
        
        public IHttpActionResult GetProduct(int id)
        {
            using (productORMDataContext productOrm = new productORMDataContext())
            {
                tblProduct thisProduct = (from tblProduct in productOrm.tblProducts
                                       where tblProduct.Id == id
                                       select tblProduct).SingleOrDefault();
                if (thisProduct == null)
                {
                    return NotFound();
                }
                return Ok(thisProduct);
            }
        }
        
    }
}