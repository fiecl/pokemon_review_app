

using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {

        // base is going to shove all of this data that's going to be received from outside of the class up to the DbContext
        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        // Telling the Context what all our tables are
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        // For Many-to-Many tables, still need to use OnModelCreating(), even though this is abstracting
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: Study how these work!!
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId }); // This method sets a composite primary key for the PokemonCategory entity.
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon) // This method configures the relationship to indicate that PokemonCategory has one Pokemon.
                .WithMany(pc => pc.PokemonCategories) //  This method configures the other side of the relationship, indicating that one Pokemon can have many PokemonCategory entities.
                .HasForeignKey(p => p.PokemonId); // This method sets PokemonId as the foreign key in PokemonCategory that references the Pokemon entity.
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.PokemonOwners)
                .HasForeignKey(c => c.OwnerId);




        }


    }
}
