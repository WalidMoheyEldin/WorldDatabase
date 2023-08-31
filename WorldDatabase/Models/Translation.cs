namespace WorldDatabase.Models
{
    public class Translation
    {
        public int Id { get; set; }
        public string Kr { get; set; }
        public string PtBR { get; set; }
        public string Pt { get; set; }
        public string Nl { get; set; }
        public string Hr { get; set; }
        public string Fa { get; set; }
        public string De { get; set; }
        public string Es { get; set; }
        public string Fr { get; set; }
        public string Ja { get; set; }
        public string It { get; set; }
        public string Cn { get; set; }
        public string Tr { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
