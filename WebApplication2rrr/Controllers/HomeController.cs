using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2rrr.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication2rrr.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            ViewBag.ActiveUser = PersonalCabinetController.userNow;
            return View("~/Views/Catalog.cshtml", db.Phones.ToList());
        }
    }
}