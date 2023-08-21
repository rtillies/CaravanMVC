using CaravanMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.Controllers
{
	public class StatisticsController : Controller
	{
		private readonly CaravanMvcContext _context;

		public StatisticsController(CaravanMvcContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var wagons = _context.Wagons.Include(w => w.Passengers).ToList();

			var destinations = new List<string>();
			foreach(var wagon in wagons)
			{
				destinations.AddRange(wagon.getDestinationList());
			}
			ViewData["DestinationList"] = destinations.Distinct().ToList();

			return View(wagons);
		}
	}
}
