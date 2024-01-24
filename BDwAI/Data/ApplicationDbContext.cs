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
        public DbSet<BDwAI.Models.Rezerwacja> Rezerwacja { get; set; } = default!;
    }
}
