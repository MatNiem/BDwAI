using System.ComponentModel.DataAnnotations;

namespace BDwAI.Models
{
    public class Placowka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nazwa { get; set; }

        [MaxLength(255)]
        public string Miasto { get; set; }

        public int Ocena { get; set; }

        [MaxLength (500)]
        public string Opis {  get; set; }

        public List<Zdjecie> Zdjecia { get; set; }

        public List<Lekarz> Lekarze { get; set; }

        public List<Opinia> Opinie { get; set; }
    }
}
