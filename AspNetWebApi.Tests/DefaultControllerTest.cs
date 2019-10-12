using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AspNetWebApi.Tests
{
    [TestClass]
    public class DefaultControllerTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            var testProducts = GetTestProducts();
            var controller = new AspNetWebApi.Controller.DefaultController();
            var result = controller.Get();
        }
    }
}
