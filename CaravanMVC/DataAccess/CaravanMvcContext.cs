using CaravanMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.DataAccess
{
    public class CaravanMvcContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Wagon> Wagons { get; set; }

		public CaravanMvcContext(DbContextOptions<CaravanMvcContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Wagon>().HasData(
				new Wagon { Id = 1, Name = "Lexi Silver", NumWheels = 4, IsCovered = true },
				new Wagon { Id = 2, Name = "Clifford", NumWheels = 4, IsCovered = false }
			);

			modelBuilder.Entity<Passenger>().HasData(
				new Passenger { Id = 1, Name = "Professor", Age = 28, Destination = "Virginia", WagonId = 1 },
				new Passenger { Id = 2, Name = "Bella", Age = 22, Destination = "North Carolina", WagonId = 2 },
				new Passenger { Id = 3, Name = "Seneca", Age = 28, Destination = "Virginia", WagonId = 1 },
				new Passenger { Id = 4, Name = "Carolyn", Age = 35, Destination = "Virginia", WagonId = 2 }
			);
		}


	}
}
