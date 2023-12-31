﻿namespace MovieRentalApplication.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
    }
}
