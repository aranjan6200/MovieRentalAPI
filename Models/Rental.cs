namespace MovieRentalApplication.Models
{
    public class Rental
    {
        public int RentalID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
