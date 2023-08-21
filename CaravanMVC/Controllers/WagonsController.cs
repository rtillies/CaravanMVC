using CaravanMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.Controllers
{
    public class WagonsController : Controller
    {
        private readonly CaravanMvcContext _context;

        public WagonsController(CaravanMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var wagons = _context.Wagons.ToList();
            return View(wagons);
        }

		[Route("wagons/{id:int}")]

		public IActionResult Show(int id)
        {
			var wagon = _context.Wagons.Include(w => w.Passengers).Where(w => w.Id == id).First();
			return View(wagon);
		}
	}
}
