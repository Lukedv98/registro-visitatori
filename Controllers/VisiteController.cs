using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroVisitatori.Data;
using RegistroVisitatori.Models;

namespace RegistroVisitatori.Controllers
{
    [RequireLogin]
    public class VisiteController : Controller
    {
        private readonly AppDbContext _db;

        public VisiteController(AppDbContext db)
        {
            _db = db;
        }

        // Visitatori presenti
        public async Task<IActionResult> Presenti()
        {
            var presenti = await _db.Visite
                .Where(v => v.OraUscita == null)
                .OrderByDescending(v => v.OraIngresso)
                .ToListAsync();

            return View(presenti);
        }

        // Storico visitatori
        [HttpGet]
        public async Task<IActionResult> Storico(DateTime? da, DateTime? a)
        {
            var query = _db.Visite
                .Where(v => v.OraUscita != null)
                .AsQueryable();

            if (da.HasValue)
                query = query.Where(v => v.OraIngresso.Date >= da.Value.Date);

            if (a.HasValue)
                query = query.Where(v => v.OraIngresso.Date <= a.Value.Date);

            var storico = await query
                .OrderByDescending(v => v.OraIngresso)
                .ToListAsync();

            return View(storico);
        }


        // Nuovo visitatore
        [HttpGet]
        public IActionResult Nuovo()
        {
            return View();
        }

        // Nuovo visitatore (salva)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nuovo(Visita visita)
        {
            if (!ModelState.IsValid)
                return View(visita);

            visita.OraIngresso = DateTime.Now;
            visita.OraUscita = null;

            _db.Visite.Add(visita);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Presenti));
        }

        // Registra uscita
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistraUscita(int id)
        {
            var visita = await _db.Visite.FindAsync(id);
            if (visita == null) return NotFound();
            if (visita.OraUscita != null) return RedirectToAction(nameof(Presenti));


            visita.OraUscita = DateTime.Now;
            await _db.SaveChangesAsync();

            TempData["Success"] = "Uscita registrata correttamente.";
            return RedirectToAction(nameof(Presenti));

        }

        // Elimina una visita (con redirect alla pagina di provenienza)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Elimina(int id, string returnTo = "Presenti", string password = "")
        {
            const string DELETE_PASSWORD = "admin"; // password

            // Controllo password
            if (password != DELETE_PASSWORD)
            {
                TempData["DeleteError"] = "Password non valida. Eliminazione annullata.";
                TempData["OpenDeleteModal"] = "1";
                TempData["DeleteId"] = id;
                TempData["DeleteReturnTo"] = returnTo;
                return RedirectToAction(returnTo);
            }


            var visita = await _db.Visite.FindAsync(id);
            if (visita == null) return NotFound();

            _db.Visite.Remove(visita);
            await _db.SaveChangesAsync();

            TempData["Success"] = "Visita eliminata correttamente.";
            return RedirectToAction(returnTo);
        }


    }

}
