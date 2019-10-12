using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApi.Controller
{
    public class DefaultController : ApiController
    {
        public DefaultController() { }

        // GET: api/Default1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default1
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default1/5
        public void Delete(int id)
        {
        }

        List<Models.Product> products = new List<Models.Product>();
        public IEnumerable<Models.Product> GetAllProducts()
        {
            return products;
        }
    }
}
