using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMenu.Entities;

namespace MVCMenus.Controllers
{
    [Authorize]
    public class MenusController : Controller
    {
        // GET: Menus
        public ActionResult Index()
        {
            List<Menus> m;
            using (var r = new MenusEntities())
            {
                m = r.Menus.ToList();
            }
            return View(m);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var menusmodel = new Menus();
            TryUpdateModel(menusmodel);

            using (var r = new MenusEntities())
            {
                r.Menus.Add(menusmodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string code)
        {
            var menumodel = new Menus();
            TryUpdateModel(menumodel);

            using (var r = new MenusEntities())
            {
                menumodel = r.Menus.FirstOrDefault(x => x.MenuCode == code);
            }

            return View(menumodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(string code)
        {
            var menumodel = new Menus();
            TryUpdateModel(menumodel);

            using (var r = new MenusEntities())
            {
                menumodel = r.Menus.Where(x => x.MenuCode == code).FirstOrDefault();
            }

            return View(menumodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string code)
        {
            var menumodel = new Menus();
            TryUpdateModel(menumodel);

            using (var r = new MenusEntities())
            {
                var m = r.Menus.Where(x => x.MenuCode == code).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string code)
        {
            var menumodel = new Menus();
            TryUpdateModel(menumodel);

            using (var r = new MenusEntities())
            {
                menumodel = r.Menus.FirstOrDefault(x => x.MenuCode == code);
            }

            return View(menumodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string code)
        {
            var menumodel = new Menus();
            TryUpdateModel(menumodel);

            using (var r = new MenusEntities())
            {
                var m = r.Menus.Remove(r.Menus.FirstOrDefault(x => x.MenuCode == code));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}