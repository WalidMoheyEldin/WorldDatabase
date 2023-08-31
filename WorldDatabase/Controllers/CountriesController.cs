using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorldDatabase.Data;
using WorldDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace WorldDatabase.Controllers
{
    public class CountriesController : Controller
    {
        private readonly DatabaseContext db;

        public CountriesController(DatabaseContext db) => this.db = db;

        public IActionResult Index()
        {
            List<Country> countryList = db.Countries.ToList();
            return View(countryList);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Country country = db.Countries.Include(c => c.Translations).Include(c => c.States).ThenInclude(c => c.Cities)
                .FirstOrDefault(c => c.Id == id);
            return View(country);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}