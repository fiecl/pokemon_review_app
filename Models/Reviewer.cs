﻿namespace PokemonReviewApp.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // One-to-Many
        public ICollection<Review> Reviews { get; set; }
    }
}
