using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2rrr.Models;

namespace WebApplication2rrr.Controllers
{
    public class BuyController : Controller
    {
        private readonly MobileContext db;
        private static int? PhoneId;

        public BuyController(MobileContext context)=>
            db = context;

        [HttpGet]
        public IActionResult GetBuy(int id)
        {
            Phone? phone = db.Phones.Find(id);
            PhoneId = id;

            if(phone is null)
                return NotFound();

            if (PersonalCabinetController.userNow is null)
                return NotFound();

            return View("~/Views/buy.cshtml", phone);
        }

        [HttpPost]
        public IActionResult PostBuy(string adress)
        {
            User? user = PersonalCabinetController.userNow;

            if (user is null || PhoneId is null)
                return NotFound();

            db.Orders.Add(new Order
            {
                UserId = user.UserId,
                Address = adress,
                ContactTelephone = user.NumberTelephone,
                PhoneId = (int)PhoneId
            });
            db.SaveChanges();
            return View("~/Views/Thanks.cshtml");
        }
    }
}
