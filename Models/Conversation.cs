namespace BartmartWeb.Models
{
    public class Conversation
    {
        public string ConversationID { get; set; }
        public string UserID { get; set; }
        public string ListingID { get; set; }
        public string OtherUserID { get; set; }
        public List<Message> Messages { get; set; }
    }
}
