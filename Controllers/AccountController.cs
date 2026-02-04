using Microsoft.AspNetCore.Mvc;

namespace RegistroVisitatori.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
                return RedirectToAction("Presenti", "Visite");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string? username, string? password)
        {
            username = username?.Trim();
            password = password?.Trim();

            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Inserisci username e password.";
                return View();
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                ViewBag.Error = "Inserisci lo username.";
                return View();
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Inserisci la password.";
                ViewBag.Username = username; // così non perdo lo username inserito
                return View();
            }

            // LOGIN
            if (username == "Luca D." && password == "admin")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Presenti", "Visite");
            }

            // credenziali errate
            ViewBag.Error = "Credenziali non valide. Verifica username e password e riprova.";
            ViewBag.Username = username; // così non perdo lo username inserito
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
        }
    }
}