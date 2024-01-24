using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BDwAI.Models;

namespace BDwAI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BDwAI.Models.Placowka> Placowka { get; set; } = default!;
<<<<<<< HEAD
        public DbSet<BDwAI.Models.Rezerwacja> Rezerwacja { get; set; } = default!;
=======
        public DbSet<BDwAI.Models.Zdjecie> Zdjecia { get; set; } = default!;
        public DbSet<BDwAI.Models.Opinia> Opinie { get; set; } = default!;
        public DbSet<BDwAI.Models.Lekarz> Lekarze { get; set; } = default!;
        public DbSet<BDwAI.Models.Rezerwacja> Rezerwacje { get; set; } = default!;
        public DbSet<BDwAI.Models.Uzytkownik> Uzytkownicy { get; set; } = default!;
>>>>>>> master/master
    }
}
