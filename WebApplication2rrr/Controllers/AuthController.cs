using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication2rrr.Models;

namespace WebApplication2rrr.Controllers
{
    public class AuthController : Controller
    {
        private readonly MobileContext _context;
        public AuthController(MobileContext context)=>
            _context = context;

        [HttpGet]
        public IActionResult Index()=>
            View("~/Views/Authorization.cshtml", "");

        [HttpPost]
        public IActionResult Authorization(string login, string password)
        {
            User? a = _context.Users.Where(u => u.Login == login).FirstOrDefault();

            if (a is null)
                return View("~/Views/Authorization.cshtml", "Логин не найден");

            if (a.Password != Hash.GetHashPass(password))
                return View("~/Views/Authorization.cshtml", "Пароль не правильный");

            PersonalCabinetController.userNow = a;
            return View("~/Views/Personal.cshtml", PersonalCabinetController.userNow);
        }
    }
}
