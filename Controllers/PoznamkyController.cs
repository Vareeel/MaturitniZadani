using Microsoft.AspNetCore.Mvc;

namespace maturitniZadani.Controllers
{
    public class PoznamkyController : Controller
    {
        public IActionResult Poznamky()
        {
            return View();
        }
    }
}
