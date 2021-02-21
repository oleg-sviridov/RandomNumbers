using Microsoft.EntityFrameworkCore;
using RandomNumbers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomNumbers.Database
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// Data context constructor.
        /// </summary>
        /// <param name="options">DbContextOptions.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Match table.
        /// </summary>
        public DbSet<Match> Matches { get; set; }

        /// <summary>Gets or sets User table.
        /// </summary>
        public DbSet<User> Users { get; set; }

        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Match>(builder =>
            {
                builder.ToTable("Matches");
            });

            modelBuilder
            .Entity<User>(builder =>
            {
                builder.ToTable("Users");
            });

            modelBuilder
            .Entity<Result>(builder =>
            {
                builder.ToTable("Results");
            });
        }
    }
}
