using EronCoreProject.Config;
using EronCoreProject.Entegrations;
using EronCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EronCoreProject.Controllers
{
    public class CategoriesController : Controller
    {
        private EronEntegration _eronEntegration;

        public CategoriesController()
        {
            _eronEntegration = new EronEntegration();
        }

        public IActionResult Index()
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            ViewBag.categories = _eronEntegration.GetAllCategories();
            return View();
        }

        public IActionResult Add()
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            return View();
        }
        public IActionResult Update(int id)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            var category=_eronEntegration.GetAllCategories().Find(c => c.e_id == id);
            if(category==null)
                return RedirectToAction("Index");
            ViewBag.category = category;
            return View();
        }
        public IActionResult Save(CategoryAddModel category)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            _eronEntegration.CategoryAdd(category);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(CategoryUpdateModel category)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            _eronEntegration.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            _eronEntegration.CategoryDelete(new CategoryDeleteModel(id));
            return RedirectToAction("Index");
        }
    }
}
