using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace AspNetWebApi.Tests
{
    [TestClass]
    public class DefaultControllerTest
    {
        /// <summary>
        /// テストの初期設定
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            //HTTPコンテキストを設定していく

            //Step1: HTTP Request を作成
            System.Web.HttpRequest httpRequest = new HttpRequest("", "http://localhost/", "");

            //STEP2: HTTP Response を作成
            System.Web.HttpResponse httpResponse = new HttpResponse(new System.IO.StringWriter());

            //STEP3: HTTP Context を作成
            System.Web.HttpContext httpContext = new System.Web.HttpContext(httpRequest, httpResponse);

            var sessionContainer = new System.Web.SessionState.HttpSessionStateContainer("id",
                new System.Web.SessionState.SessionStateItemCollection(),
                new System.Web.HttpStaticObjectsCollection(),
                10,
                true,
                HttpCookieMode.AutoDetect,
                SessionStateMode.InProc,
                false
            );

            httpContext.Items["AspSession"] =
                typeof(HttpSessionState).GetConstructor(
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                    null,
                    System.Reflection.CallingConventions.Standard,
                    new[] { typeof(HttpSessionStateContainer) },
                    null
                ).Invoke(new object[] { sessionContainer });

            //Step4: HttpContext に代入する
            HttpContext.Current = httpContext;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var controller = new AspNetWebApi.Controller.DefaultController();
            var result = controller.Get();
        }

        [TestMethod]
        public void TestMethod2()
        {
            //NullPointerの例外は回避できるようになったが
            //この方法だとテスト実行時、resultに入らない....。原因は分からない。   
            var controller = new AspNetWebApi.Controller.DefaultController();
            var result = controller.Get("hogehoge");
            result = controller.Get("hugahuga");
        }
    }
}
