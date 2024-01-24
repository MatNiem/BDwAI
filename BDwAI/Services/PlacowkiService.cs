using BDwAI.Data;
using BDwAI.Models;
using Microsoft.EntityFrameworkCore;

namespace BDwAI.Services
{
    public class PlacowkiService : IPlacowkiService
    {
        private readonly ApplicationDbContext _context;

        public PlacowkiService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Placowka GetPlacowka(int id)
        {
            return _context.Placowka
                    .Include(p => p.Zdjecia)
                    .Include(p => p.Lekarze)
                    .Include(p => p.Opinie)
                    .ThenInclude(o => o.Uzytkownik)
                    .FirstOrDefault(p => p.Id == id);
        }

        public string GetPlacowkaImage(int placowkaId)
        {
            var placowka = GetPlacowka(placowkaId);
            if (placowka != null && placowka.Zdjecia != null && placowka.Zdjecia.Any())
            {
                // Zwróć ścieżkę do pierwszego zdjęcia
                return placowka.Zdjecia.First().Url;
            }

            return "lmao";
        }

        public List<Placowka> GetPlacowkas()
        {
            return _context.Placowka.ToList();
        }
    }
}
