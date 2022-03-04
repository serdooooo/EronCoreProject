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
    public class UsersController : Controller
    {
        private EronEntegration _eronEntegration;
        public UsersController()
        {
            _eronEntegration = new EronEntegration();
        }
        public IActionResult Index(UserAddModel users)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            ViewBag.users = _eronEntegration.GetAllUsers(users);
            return View();
        }
        public IActionResult Add()
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            return View();

        }
        public IActionResult Save(UserAddModel users)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            _eronEntegration.UserAdd(users);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            _eronEntegration.UserDelete(new UserDeleteModel(id));
            return RedirectToAction("Index");
        }
        public IActionResult Edit(UserUpdateModel users)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            _eronEntegration.UserUpdate(users);
            return RedirectToAction("Index");
        }
        public IActionResult Update(UserAddModel users,int id)
        {
            if (AppData.LoginUser == null)
                return Redirect("/Auth/Index");
            var user = _eronEntegration.GetAllUsers(users).Find(u => u.e_id == id);
            if (user == null)
                return RedirectToAction("Index");
            ViewBag.user = user;
            return View();
        }
    }
}
