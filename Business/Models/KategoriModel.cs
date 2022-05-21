using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class KategoriModel : RecordBase
    {
        [Required]
        [StringLength(100)]
        [DisplayName("Adı")]

        public string Adi { get; set; }
        [DisplayName("Açıklaması")]
        public string Aciklamasi { get; set; }
        
        [DisplayName("Ürün sayısı")]
        public int UrunSayisiDisplay { get; set; }
    }
}
