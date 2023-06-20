namespace MovieRentalApplication.Models
{
    public class RentalDetail
    {
        public int RentalDetailID { get; set; }
        public int RentalID { get; set; }
        public int MovieID { get; set; }
        public Rental Rental { get; set; }
        public Movie Movie { get; set; }
    }
}
