using Microsoft.EntityFrameworkCore;
using WebAppliCRUD.Models;

namespace WebAppliCRUD.Data
{
    public class CardDBContext : DbContext
    {
        public CardDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
       // public DbSet<Stud> Studs { get; set; }
    }
}
