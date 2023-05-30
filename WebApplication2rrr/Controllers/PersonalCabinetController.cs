using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using WebApplication2rrr.Models;

namespace WebApplication2rrr.Controllers
{
    public class PersonalCabinetController : Controller
    {
        public static User? userNow = null;
        private readonly MobileContext _context;

        public PersonalCabinetController(MobileContext context) =>
            _context = context;

        [HttpGet]
        public IActionResult Index() =>
            View("~/Views/Personal.cshtml", userNow);

        [HttpPost]
        public async Task<IActionResult> PostUdate(string name, string phone)
        {
            if (userNow is null)
                return NotFound("пользователя нет");

            userNow.Name = name;
            userNow.NumberTelephone = phone;

            _context.Update(userNow);
            await _context.SaveChangesAsync();

            return View("~/Views/Personal.cshtml", userNow);
        }

        [HttpGet]
        public IActionResult GetHistory()
        {
            if (userNow is null)
                return NotFound("пользователь не задан");

            return View("~/Views/History.cshtml", _context.Orders.Where(p=> p.UserId == userNow.UserId).Select(u => u.Phone).ToList());
        }

        [HttpGet]
        public IActionResult GetExit()
        {
            userNow = null;
            return View("~/Views/Authorization.cshtml", null);
        }
    }
}
