namespace BartmartWeb.Models
{
    public class Wishlist
    {
        public string WishlistID { get; set; }
        public string UserID { get; set; }
        public List<Listing> Listings { get; set; }
    }
}
