using Microsoft.EntityFrameworkCore;
using NewsApplication2.Models;
using System.Collections.Generic;

namespace NewsApplication2.DataAccess.Concrete
{
    public class NewsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=newsDB; Trusted_Connection=True; TrustServerCertificate=True;");
        }
        public DbSet<News> news { get; set; }
    }
}
