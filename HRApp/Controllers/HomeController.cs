using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRApp.Models;

namespace HRApp.Controllers
{
    public class HomeController : Controller
    {
        public static List<ProgrammerDecorator> Programmers = new List<ProgrammerDecorator>();

        public HomeController(){
            if(!Programmers.Any()){
                JuniorDev Junior = new JuniorDev(new Programmer(1, "Luis Correa", "data/arch.jpg"));
                SeniorDev Senior = new SeniorDev(new Programmer(2, "Jorge Villawolves", "data/arch.jpg"));
                ArchitechtDev Architecht = new ArchitechtDev(new Programmer(3, "Sebastián Franco", "data/arch.jpg"));

                //List<ProgrammerDecorator> Programmers = new List<ProgrammerDecorator>();
                Programmers.Add(Junior);
                Programmers.Add(Senior);
                Programmers.Add(Architecht);
            }
        }

        public IActionResult Index()
        {
            return View(Programmers);
        }

        public IActionResult PromoteProgrammer(int ID)
        {
            var res = Programmers.Find(x => x.GetProgramer().ID == ID);
            int idx = Programmers.IndexOf(res);
            res = res.Promote();
            Programmers[idx] = res;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DemoteProgrammer(int ID)
        {
            var res = Programmers.Find(x => x.GetProgramer().ID == ID);
            int idx = Programmers.IndexOf(res);
            res = res.Demote();
            Programmers[idx] = res;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddProgrammer()
        {
            return View()
        }

        [HttpPost]
        public IActionResult AddProgrammer(IProgrammer model)
        {
            return View()
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
