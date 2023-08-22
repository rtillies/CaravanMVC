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

			int totalAge = 0;
			int totalPassengers = 0;
            foreach (var wagon in wagons)
            {
				totalAge += wagon.TotalAge();
				totalPassengers += wagon.Passengers.Count;
            }
			var averageAge = totalPassengers > 0 ? totalAge / totalPassengers : 0;


            ViewData["TotalAge"] = totalAge;
            ViewData["TotalPassengers"] = totalPassengers;
            ViewData["AverageAge"] = averageAge;


            return View(wagons);
		}
	}
}
