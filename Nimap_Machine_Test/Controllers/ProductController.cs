using Nimap_Machine_Test.Models;
using Nimap_Machine_Test.Models.Validation_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nimap_Machine_Test.Controllers
{
    public class ProductController : Controller
    {
        private Nimap_MVC_Machine_TestEntities dbo = new Nimap_MVC_Machine_TestEntities();

        // GET: Product
        public ActionResult Index()
        { 
            List<tblProduct> products = dbo.tblProducts.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Product_valid_Class prvc)
        {
            if (ModelState.IsValid)
            {
                tblProduct prd = new tblProduct();
                prd.Product_id = prvc.Product_id;
                prd.Product_Name = prvc.Product_Name;

                dbo.tblProducts.Add(prd);
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
            int pid = int.Parse(id);
            var prdt = dbo.tblProducts.Find(pid);
            Product_valid_Class pvc = new Product_valid_Class();
            pvc.Product_id = prdt.Product_id;
            pvc.Product_Name = prdt.Product_Name;

            return View(pvc);
        }


        [HttpPost]
        public ActionResult Update(Product_valid_Class pdv)
        {
            if (ModelState.IsValid)
            {
                var prdt = dbo.tblProducts.FirstOrDefault(x=>x.Product_id == pdv.Product_id);

                prdt.Product_Name = pdv.Product_Name;

                    int n= dbo.SaveChanges();
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
            tblProduct prdct = dbo.tblProducts.Find(id);
            Product_valid_Class pvc = new Product_valid_Class();
            pvc.Category_id = prdct.Category_id;
            pvc.Product_id=prdct.Product_id;
            pvc.Product_Name=prdct.Product_Name;
           
            return View(pvc);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblProduct prdct = dbo.tblProducts.Find(id);
            if (prdct != null)
            {
                dbo.tblProducts.Remove(prdct);
                int n = dbo.SaveChanges();
            }    
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IndexSearch(string txtSearch, int? i)
        {

            return View();
        }
    }
}
