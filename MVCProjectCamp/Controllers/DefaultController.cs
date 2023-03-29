using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectCamp.Controllers
{
    [AllowAnonymous] //Login sayfasına yönlendirilmeden bu sayfa açılabilsin diye
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm= new ContentManager(new EFContentDal());
        // GET: Default
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = cm.GetListByHeadingID(id);
            return PartialView(contentList);    
        }
        public PartialViewResult AllArticles()
        {
            var articleList = cm.GetAll();
            return PartialView(articleList);   
        }

    }
}