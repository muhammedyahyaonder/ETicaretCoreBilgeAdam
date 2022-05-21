using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class KullaniciDetayi
    {
        [Key]
        public int KullaniciId { get; set; }

        public Kullanici Kullanici { get; set; }

        [Required]
        [StringLength(200)]
        public string Eposta { get; set; }

        [Required]
        public string Adres { get; set; }
        public Cinsiyet Cinsiyet { get; set; }

    }
}
