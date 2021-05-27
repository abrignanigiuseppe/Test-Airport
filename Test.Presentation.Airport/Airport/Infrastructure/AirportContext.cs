namespace Airport.Api.Infrastructure
{
    using Airport.Api.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Defines the <see cref="AirportContext" />.
    /// </summary>
    public class AirportContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirportContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{AirportContext}"/>.</param>
        public AirportContext(DbContextOptions<AirportContext> options)
                    : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Airports.
        /// </summary>
        public DbSet<Airport> Airports { get; set; }
    }

    public class AirportContextDesignFactory : IDesignTimeDbContextFactory<AirportContext>
    {
        public AirportContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AirportContext>()
                .UseInMemoryDatabase("AirPort");
                //.UseSqlServer("Server=.;Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb;Integrated Security=true");

            return new AirportContext(optionsBuilder.Options);
        }
    }
}
