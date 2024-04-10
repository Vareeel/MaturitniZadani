using maturitniZadani.Data;
using Microsoft.AspNetCore.Mvc;

namespace maturitniZadani.Controllers
{

    public class PoznamkyController : Controller
    {
        Maturita databaze { get; set; }

        public PoznamkyController(Maturita Databaze) => databaze = Databaze;




        [HttpPost]
        public IActionResult pridat(string nadpis, string text, string dulezitost)
        {

            Models.PoznamkyModel nova_poznamka = new Models.PoznamkyModel()
            {
                Nadpis = nadpis,
                Obsah = text,
                CasPridani = DateTime.Now,
                JeDulezita = dulezitost == "on",
                MajitelId = HttpContext.Session.GetString("jmeno")

            };
            databaze.Add(nova_poznamka);
            databaze.SaveChanges();

            return RedirectToAction("Poznamky");
        }
        
       
        [HttpGet]
        public IActionResult Pridat()
        {
            return View();
        }


    }
}
