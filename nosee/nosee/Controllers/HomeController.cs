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

        public ActionResult About()
        {
            var items = new List<Item>();
            using (ApiCaller apiCaller = new ApiCaller())
            {
                items = apiCaller.GetAllItems();
            }
            return View(items);
        }

        public ActionResult Contact()
        {

            return View(new Item());
        }
        
        [HttpPost]
        public ActionResult Contact(Item model)
        {
            var result = 0;
            if(ModelState.IsValid)
            {
                using (ApiCaller apiCaller = new ApiCaller())
                {
                    result = apiCaller.InsertItem(model);
                }
                return RedirectToAction("About");
            }
            return View(model);
        }
    }
}