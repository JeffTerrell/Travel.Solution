using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
  public class TravelContext : DbContext
  {
    public TravelContext(DbContextOptions<TravelContext> options)
      : base(options)
      {
      }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Destination>()
        .HasData(
          new Destination { DestinationId = 1, City = "New York", State = "New York", Country = "United States", Review = "Awesome city to visit!", Rating = 3 },
          new Destination { DestinationId = 2, City = "Seattle", State = "Washington", Country = "United States", Review = "Awesome city to visit!", Rating = 7 },
          new Destination { DestinationId = 3, City = "Seattle", State = "Washington", Country = "United States", Review = "Awesome city to visit!", Rating = 7 },
          new Destination { DestinationId = 4, City = "Portland", State = "Oregon", Country = "United States", Review = "Awesome city to visit!", Rating = 8 },
          new Destination { DestinationId = 5, City = "Boise", State = "Idaho", Country = "United States", Review = "Awesome city to visit!", Rating = 5 }
      );
    }

      public DbSet<Destination> Destinations { get; set; }
  }
}