namespace WorldDatabase.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Country_id { get; set; }
        public string State_code { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Country Country { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
