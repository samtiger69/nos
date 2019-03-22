using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nosee.Models;

namespace nosee.Controllers
{
    public class ItemController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (var db = new ApplicationDbContext())
            {
                var item = db.Items.FirstOrDefault();

                if (item == null)
                {
                    return Ok(1);
                }

                return Ok(item.Value);
            }
        }


        [HttpGet]
        public IHttpActionResult Create(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var item = db.Items.FirstOrDefault();

                if (item == null)
                {
                    item = new Item
                    {
                        Value = id
                    };
                    db.Items.Add(item);
                    db.SaveChanges();
                    return Ok();
                }
                item.Value = id;
                db.SaveChanges();
                return Ok();
            }
        }

    }
}
