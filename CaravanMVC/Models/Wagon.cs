namespace CaravanMVC.Models
{
	public class Wagon
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumWheels { get; set; }
        public bool IsCovered { get; set; }
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();

        public HashSet<string> getDestinationList()
        {
            var destinationList = new List<string>();
            foreach(var passenger in Passengers)
            {
                destinationList.Add(passenger.Destination);
            }
            return new HashSet<string>(destinationList);
        }

        public int TotalAge()
        {  
            int total = 0;
            if (Passengers != null && Passengers.Count > 0)
            {
                foreach(var passenger in Passengers)
                {
                    total += passenger.Age;
                }
            }
            return total;
        }

        public double AverageAge()
        {
            return TotalAge() > 0 ? TotalAge() / Passengers.Count : 0;
        }
    }
}
