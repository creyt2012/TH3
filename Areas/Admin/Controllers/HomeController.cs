﻿using Microsoft.AspNetCore.Mvc;

namespace TH3_Harmic.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
