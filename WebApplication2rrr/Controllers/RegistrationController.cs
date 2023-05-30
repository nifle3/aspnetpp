using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;
using System.Text.RegularExpressions;

namespace WebApplication2rrr.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MobileContext _context;

        public RegistrationController(MobileContext context) =>
            _context = context;

        [HttpGet]
        public IActionResult Index()=>
            View("~/Views/Regestration.cshtml");

        [HttpPost]
        public async Task<IActionResult> PostSetUser(User user)
        {
            string s = "Ошибка";
            try
            {
                user.Password = Hash.GetHashPass(user.Password);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return View("~/Views/Authorization.cshtml");
        }
    }
}
