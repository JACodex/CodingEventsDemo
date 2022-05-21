using CodingEventsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsDemo.Data
{
    public class EventDbContext : DbContext 
    {
        public DbSet<Event> Events { get; set; }
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Chinook");
        //    }
        //}
    }
}
