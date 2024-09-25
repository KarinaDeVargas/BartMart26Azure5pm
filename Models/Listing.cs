namespace BartmartWeb.Models
{
    public class Listing
    {
        public string ListingID { get; set; }
        public string Title { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Condition { get; set; }
        public string ImageURL { get; set; }
        public bool isChangeable { get; set; }
        public double Price { get; set; }
        public double CryptoValue { get; set; }
        public DateTime ListingCreationDate { get; set; }
        public int ListingViews { get; set; }
        public string ListingStatus { get; set; }
    }

}
