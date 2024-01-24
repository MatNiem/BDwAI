using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDwAI.Models
{
    public class Zdjecie
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Url { get; set; }

        [ForeignKey("Placowka")]
        public int PlacowkaId { get; set; }
        public Placowka Placowka { get; set; }
    }
}
