﻿namespace PokemonReviewApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Many-to-Many
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
