using Microsoft.AspNetCore.Mvc;
using maturitniZadani.Data;
using maturitniZadani.Models;

namespace maturitniZadani.Controllers
{
    public class UzivateleController : Controller
    {

        Maturita databaze {  get; set; }

        public UzivateleController(Maturita Databaze) => databaze = Databaze;



        [HttpGet]
        public IActionResult prihlaseni() {
            return View();
        
        
        
        }



        [HttpPost]
        public IActionResult prihlaseni(string? jmeno, string? heslo)
        {
            if (jmeno == null)
            {
                return RedirectToAction("Prihlaseni");
            }

            if (heslo == null) {
                return RedirectToAction("Prihlaseni");
            }

            heslo = heslo.Trim();

            UzivateleModel? uzivatelexistuje = databaze.Uzivatele
            .Where(n => n.Jmeno == jmeno)
            .FirstOrDefault();




            if (uzivatelexistuje == null) { 
                return RedirectToAction("Prihlaseni");
            }

            if (BCrypt.Net.BCrypt.Verify(heslo, uzivatelexistuje.Heslo_hashed)) {
                HttpContext.Session.SetString("prihlasenyUzivatel", jmeno);
                return RedirectToAction("Poznamky", "Poznamky");
            }

            return RedirectToAction("Prihlaseni");
        }



        [HttpGet]
        public IActionResult Registrace()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrace(string jmeno, string heslo, bool? souhlas)
        {
            UzivateleModel? uzivatelexistuje = databaze.Uzivatele.FirstOrDefault(user => user.Jmeno == jmeno);


            if (souhlas == true)
            {
                return RedirectToAction("Prihlaseni");
            }


            UzivateleModel uzivatelNew = new UzivateleModel
            {
                Jmeno = jmeno,
                Heslo_hashed = BCrypt.Net.BCrypt.HashPassword(heslo)
            };

            databaze.Uzivatele.Add(uzivatelNew);
            databaze.SaveChanges();

            return RedirectToAction("Prihlaseni");
        }
    }
}

