using Nimap_Machine_Test.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nimap_Machine_Test.Controllers
{
    public class CombineController : Controller
    {
        // GET: Combine
        Nimap_MVC_Machine_TestEntities dbo = new Nimap_MVC_Machine_TestEntities();
        [HttpGet]
        public ActionResult Index(int? i)
        {
            var list = dbo.sp_join().ToList().ToPagedList(i ?? 1, 10);

            return View(list);
        }
        [HttpGet]
        public ActionResult IndexSearch(string txtSearch, int? i)
        {
            //var list = dbo.sp_join().ToList().ToPagedList(i ?? 1, 5);          
            var Tlist = dbo.sp_join().ToList();
            var list = Tlist.Where(x => x.Category_Name.ToLower().Contains(txtSearch)).ToList().ToPagedList(i ?? 1, 10);
            return View("Index", list);
        }
    }
}