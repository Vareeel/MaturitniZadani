using Microsoft.EntityFrameworkCore;

namespace maturitniZadani.Data
{
    public class Maturita : DbContext
    {



        public DbSet<Models.UzivateleModel> Uzivatele { get; set; }
        public DbSet<Models.PoznamkyModel> Poznamky { get; set; }






        public Maturita(DbContextOptions<Maturita> options) : base(options) { }
    }
}
