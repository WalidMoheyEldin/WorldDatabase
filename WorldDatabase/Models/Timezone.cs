namespace WorldDatabase.Models
{
    public class Timezone
    {
        public int Id { get; set; }
        public string ZoneName { get; set; }
        public int GmtOffset { get; set; }
        public string GmtOffsetName { get; set; }
        public string Abbreviation { get; set; }
        public string TzName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
