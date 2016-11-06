using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SensorController : ApiController
    {


        public IEnumerable<sensordata> GetAllData()
        {
            using (sensorORMDataContext sensorOrm = new sensorORMDataContext())
            {
                List<sensordata> sensorList = (from sensordata in sensorOrm.sensordatas
                                                select sensordata).ToList();
                return sensorList;
            }


        }

        /*
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
        }*/
    }
}
