using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDwAI.Models
{
    public class Lekarz
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Imie { get; set; }

        [MaxLength(50)]
        public string Nazwisko { get; set; }

        [MaxLength(50)]
        public string Specjalizacja { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal CenaWizyty { get; set; }

        [ForeignKey("Placowka")]
        public int PlacowkaId { get; set; }
        public Placowka Placowka { get; set; }

        public List<Rezerwacja> Rezerwacje { get; set; }
    }
}
