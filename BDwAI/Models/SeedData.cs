using BDwAI.Data;
using Microsoft.EntityFrameworkCore;

namespace BDwAI.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Uzytkownicy.Any())
                {
                    return;
                }
            }
        }
    }
}
