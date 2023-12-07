using Lab5.Models;
using LabsLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult Lab1()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Lab1(Lab1DataModel model)
        {
            var labRunner = new L1Manager(model.PricesInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(pr => Convert.ToInt32(pr)).ToList());

            try
            {
                model.Calculated = labRunner.Run();
            }
            catch (ArgumentException e)
            {
                model.ErrorValue = e.Message;
            }
            catch (Exception e)
            {
                model.ErrorValue = e.Message;
            }

            return View(model);
        }

        public IActionResult Lab2()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Lab2(Lab2DataModel model)
        {
            var labRunner = new L2Manager(model.Number);

            try
            {
                model.Calculated = labRunner.Run();
            }
            catch (ArgumentException e)
            {
                model.ErrorValue = e.Message;
            }
            catch (Exception e)
            {
                model.ErrorValue = e.Message;
            }

            return View(model);
        }

        public IActionResult Lab3()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Lab3(Lab3DataModel model)
        {
            var labRunner = new L3Manager(model.Game.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(r => r.ToCharArray()).ToArray());

            try
            {
                model.Calculated = labRunner.Run();
            }
            catch (ArgumentException e)
            {
                model.ErrorValue = e.Message;
            }
            catch (Exception e)
            {
                model.ErrorValue = e.Message;
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
