using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MyWeb.Models;
using MyWeb.ServiceReference1;

namespace MyWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.success = false;
            return View();
        }

        [HttpGet]
        public ActionResult SearchUser(int id)
        {
            ViewBag.success= false;
            UserModel user = new UserModel();

            using (ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient())
            {
                user = service.Get_User(id).Tables[0].AsEnumerable()
                .Select(dataRow => new UserModel
                {
                    Id = dataRow.Field<int>("Id"),
                    Name = dataRow.Field<string>("Name"),
                    Birthdate = dataRow.Field<DateTime>("Birthdate"),
                    Sex = dataRow.Field<String>("Sex")
                }).FirstOrDefault();
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel userModel)
        {
            ViewBag.success = false;

            if (ModelState.IsValid)
            {
                using (ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient())
                {
                    User user = new User();
                    user.Name = userModel.Name;
                    user.Birthdate = userModel.Birthdate;
                    user.Sex = userModel.Sex;

                    service.Insert_User(user);
                    ViewBag.success = true;
                    ModelState.Clear();
                }               
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(UserModel userModel)
        {
            ViewBag.success = false;

            if (ModelState.IsValid)
            {
                using (ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient())
                {
                    User user = new User();
                    user.Id = userModel.Id;
                    user.Name = userModel.Name;
                    user.Birthdate = userModel.Birthdate;
                    user.Sex = userModel.Sex;

                    service.Update_User(user);
                    ViewBag.success = true;
                    ModelState.Clear();
                    return RedirectToAction("index", "UserQuery");
                }
            }
            return View("SearchUser");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            ViewBag.success = false;
            UserModel user = new UserModel();

            using (ServiceReference1.ServiceClient service = new ServiceReference1.ServiceClient())
            {
                service.Delete_User(id);
            }

            return RedirectToAction("index", "UserQuery"); ;
        }
    }
}