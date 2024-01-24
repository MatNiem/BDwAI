using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDwAI.Models
{
    public class Rezerwacja
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Uzytkownik")]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("Lekarz")]
        public int LekarzId { get; set; }
        public Lekarz Lekarz { get; set; }

        public DateTime Data { get; set; }
    }
}
