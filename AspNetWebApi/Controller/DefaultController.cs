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

        public const string APP_VALUE_KEY_NAME = "MyAppVar1";

        public DefaultController() { }
        
        // GET: api/Default1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default1/5
        public string Get(string userId)
        {
            System.Web.HttpContext appContext  = System.Web.HttpContext.Current;

            try
            {
                //ロックされていない？
                //MyAppVar1 の値が更新されてしまう？
                appContext.Application.Lock();
                var state = System.Web.HttpContext.Current.Application[APP_VALUE_KEY_NAME];
                if (state == null)
                {
                    appContext.Application.Add(APP_VALUE_KEY_NAME, "");
                    appContext.Application[APP_VALUE_KEY_NAME] = userId;
                    return (string)appContext.Application[APP_VALUE_KEY_NAME];
                }
                else
                {
                    appContext.Application[APP_VALUE_KEY_NAME] = null;
                    return (string)appContext.Application[APP_VALUE_KEY_NAME];
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //appContext.Application.UnLock();
            }

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
