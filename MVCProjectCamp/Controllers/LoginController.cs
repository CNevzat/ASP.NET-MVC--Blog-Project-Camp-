using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EFWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x=> x.AdminUserName == p.AdminUserName
            && x.Password == p.Password ); //FirstOrDefault returns only 1 result
            //Veritabanındaki AdminUserName ile Admin sınıfından türettiğimiz p parametresindeki AdminUserName eşitse ve 
            //Veritabanındaki Password ile p parametresinden gelen Password eşitse adminUserInfo değişkenine assign et.
            if(adminUserInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;   //Oturum Yönetimi Oluşturma (Session)
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index"); //hatalı giriş yapıldı
            }            
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail
            //&& x.WriterPassword == p.WriterPassword); //FirstOrDefault returns only 1 result
            //Veritabanındaki AdminUserName ile Admin sınıfından türettiğimiz p parametresindeki AdminUserName eşitse ve 
            //Veritabanındaki Password ile p parametresinden gelen Password eşitse adminUserInfo değişkenine assign et.
            var writerUserInfo = wm.GetWriter(p.WriterMail,p.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;   //Oturum Yönetimi Oluşturma (Session)
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin"); //hatalı giriş yapıldı
            }         
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");   
        }
    }
}