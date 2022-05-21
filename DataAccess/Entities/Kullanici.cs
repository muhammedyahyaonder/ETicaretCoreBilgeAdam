using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Kullanici : RecordBase
    {
        [Required,MinLength(3),MaxLength(50)]
        public string KullaniciAdi { get; set; }
        [Required]
        [StringLength(10)]

        public string Sifre { set; get; }
        public bool AktifMi { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public KullaniciDetayi KullaniciDetayi { get; set; }
    }
}
