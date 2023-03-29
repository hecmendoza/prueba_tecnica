using MyWeb.Models;
using MyWeb.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MyWeb.Controllers
{
    public class UserQueryController : Controller
    {
        // GET: Page2
        public ActionResult Index()
        {
            using (ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient())
            {
                ViewData["users"] = service.Get_Users().Tables[0].AsEnumerable()
                .Select(dataRow => new UserModel
                {
                    Id = dataRow.Field<int>("Id"),
                    Name = dataRow.Field<string>("Name"),
                    Birthdate = dataRow.Field<DateTime>("Birthdate"),
                    Sex = dataRow.Field<String>("Sex")
                }).ToList();

            }
            return View();
        }
    }
}