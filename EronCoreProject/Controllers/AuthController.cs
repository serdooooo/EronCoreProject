using EronCoreProject.Entegrations;
using EronCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EronCoreProject.Controllers
{
    public class AuthController : Controller
    {
        private EronEntegration _eronEntegration;

        public AuthController()
        {
            _eronEntegration = new EronEntegration();
        }

        public IActionResult Index(string message)
        {
            ViewBag.message = message;
            return View();
        }

        public IActionResult DoLogin(AuthenticationModel data)
        {
            if (this._eronEntegration.Login(data))
            {
                return Redirect("/Home/Index");
            }
            return RedirectToAction("Index", new ErrorModel("Giriş bilgileri hatalı"));
        }
        public IActionResult DoLogout()
        {
            if (this._eronEntegration.Logout())
            {
                return RedirectToAction("Index", new ErrorModel("Çıkış yaptınız"));
            }
            return Redirect("/Home/Index");
        }

    }
}
