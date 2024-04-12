using maturitniZadani.Data;
using maturitniZadani.Models;
using Microsoft.AspNetCore.Mvc;
using maturitniZadani.Models;

namespace maturitniZadani.Controllers
{

    public class PoznamkyController : Controller
    {
        Maturita databaze { get; set; }

        public PoznamkyController(Maturita Databaze) => databaze = Databaze;




        [HttpPost]
        public IActionResult pridat(string nadpis, string text, string dulezitost)
        {
            if (HttpContext.Session.GetString("prihlasenyUzivatel") == null)
            {
                return RedirectToAction("Prihlaseni", "Uzivatele");
            }

            PoznamkyModel nova_poznamka = new PoznamkyModel()
            {
                Nadpis = nadpis,
                Obsah = text,
                CasPridani = DateTime.Now,
                JeDulezita = dulezitost == "on",
                MajitelId = HttpContext.Session.GetString("prihlasenyUzivatel")

            };
            databaze.Add(nova_poznamka);
            databaze.SaveChanges();

            return RedirectToAction("Vypis");

        }
        
       
        [HttpGet]
        public IActionResult Pridat()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Vypis()
        {
            if (HttpContext.Session.GetString("prihlasenyUzivatel") == null)
            {
                return RedirectToAction("Prihlaseni", "Uzivatele");
            }

            string jmeno = HttpContext.Session.GetString("prihlasenyUzivatel");
            List<PoznamkyModel> poznamky = databaze.Poznamky.Where(n => n.MajitelId == jmeno).ToList().OrderBy(o => o.CasPridani).Reverse().ToList();
            return View(poznamky);
        }




        



    }
}
