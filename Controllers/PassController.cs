using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace PassCode.Controllers
{
    public class PassController : Controller
    {
        [HttpGet]
        [Route("")]

        public IActionResult Home()
        {
            return View("Random");
        }

        [HttpPost]
        [Route("Generate")]

        public IActionResult Generate()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            int? count = 0;
            if (HttpContext.Session.GetInt32("Count") != null) {
                count = HttpContext.Session.GetInt32("Count") + 1;
            }
            else {
                count = 1;
            }
            int passcount = (int)count;
            HttpContext.Session.SetInt32("Count", passcount);
            System.Console.WriteLine(finalString);
            System.Console.WriteLine(passcount);
            ViewBag.PassCode = finalString;
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View("Random");
        }
    }
}