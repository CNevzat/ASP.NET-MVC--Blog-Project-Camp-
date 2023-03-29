using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager  adm = new AdminManager(new EFAdminDal());

        public ActionResult Index()
        {
            var adminValues = adm.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAddBl(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adm.GetByID(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {       
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}