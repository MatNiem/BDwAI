using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDwAI.Data;
using BDwAI.Models;
using Microsoft.AspNetCore.Authorization;
using BDwAI.Services;

namespace BDwAI.Controllers
{
    [Authorize]
    public class PlacowkasController : Controller
    {
        private readonly IPlacowkiService _placowkiService;

        public PlacowkasController(IPlacowkiService placowkiService)
        {
            _placowkiService = placowkiService;
        }

        // GET: Placowkas
        public async Task<IActionResult> Index()
        {
            List<Placowka> placowki = _placowkiService.GetPlacowkas();
            
            return View(placowki);
        }

        // GET: Placowkas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Placowka placowka = _placowkiService.GetPlacowka(id);

            if (TempData.ContainsKey("BladRezerwacji"))
            {
                ViewBag.BladRezerwacji = TempData["BladRezerwacji"];
            }
            if (TempData.ContainsKey("PomyslnaRezerwacja"))
            {
                ViewBag.PomyslnaRezerwacja = TempData["PomyslnaRezerwacja"];
            }

            if (placowka == null)
            {
                return NotFound();
            }

            return View(placowka);
        }
    }
}
