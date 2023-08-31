namespace WorldDatabase.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State_id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual State State { get; set; }
    }
}
