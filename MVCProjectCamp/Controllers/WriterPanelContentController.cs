using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {      
            p = (string)Session["WriterMail"];
            var writer_ID_Info = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault(); 
            var contentValues = cm.GetListByWriter(writer_ID_Info);
            return View(contentValues);    
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writer_ID_Info = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            p.WriterID = writer_ID_Info;
            p.ContentStatus = true;
            cm.ContentAddBl(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }

    }
}