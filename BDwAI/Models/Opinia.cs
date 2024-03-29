﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BDwAI.Models
{
    public class Opinia
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Tekst { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Uzytkownik")]
        public string UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("Placowka")]
        public int PlacowkaId { get; set; }
        public Placowka Placowka { get; set; }
    }
}
