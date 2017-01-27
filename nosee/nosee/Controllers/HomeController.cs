using nosee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace nosee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private List<Item> ApiCaller()
        {
            var result = new List<Item>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://webservicesapi.apphb.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Values").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<List<Item>>().Result;
                foreach (var item in items)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public ActionResult About()
        {
            var items = ApiCaller();

            return View(items);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}