using Nimap_Machine_Test.Models;
using Nimap_Machine_Test.Models.Validation_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nimap_Machine_Test.Controllers
{
    public class CategoryController : Controller
    {
        private Nimap_MVC_Machine_TestEntities dbo = new Nimap_MVC_Machine_TestEntities();

        // GET: Category
        public ActionResult Index()
        {
            List<tblCategory> categories = dbo.tblCategories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Category_valid_class ctvc)
        {
            if (ModelState.IsValid)
            {
                tblCategory ctg = new tblCategory();
                ctg.Category_id = ctvc.Category_id;
                ctg.Category_Name = ctvc.Category_Name;   

                dbo.tblCategories.Add(ctg);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }       
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            int cid = int.Parse(id);
            var ctgr = dbo.tblCategories.Find(cid);
            Category_valid_class cvc = new Category_valid_class();
            cvc.Category_id = ctgr.Category_id;
            cvc.Category_Name = ctgr.Category_Name;

            return View(cvc);
        }

        [HttpPost]
        public ActionResult Update(Category_valid_class ctc)
        {
            if (ModelState.IsValid)
            {
                var ctgr = dbo.tblCategories.FirstOrDefault(x => x.Category_id == ctc.Category_id);
                ctgr.Category_Name = ctc.Category_Name;
                int n = dbo.SaveChanges();

                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Search(int id)
        {
            tblCategory ctgry = dbo.tblCategories.Find(id);
            Category_valid_class cvc = new Category_valid_class();
            cvc.Category_id = ctgry.Category_id;
            cvc.Category_Name = ctgry.Category_Name;

            return View(cvc);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblCategory ctgry = dbo.tblCategories.Find(id);
            if(ctgry != null)
            {
                dbo.tblCategories.Remove(ctgry);
                int n = dbo.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}