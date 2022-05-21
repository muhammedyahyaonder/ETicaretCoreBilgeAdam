using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class UrunModel : RecordBase
    {
        #region Entity
        [Required(ErrorMessage = "{0} gereklidir!")]
        [MinLength(2, ErrorMessage = "{0} minimum {1} karakter olmalıdır!")]
        [DisplayName("Adı")]
        
        public string Adi { get; set; }

        [DisplayName("Birim Fiyatı")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır!")]

        public double BirimFiyati   { get; set; }

        [DisplayName("Stok Miktarı")]
        [Required(ErrorMessage = "{0} gereklidir!")]
        [Range(0, 1000000, ErrorMessage = "{0} {1} ile {2} arasında olmalıdır!")]

        public int StokMiktari { get; set; }

        [DisplayName("Son kullanma tarihi")]

        public DateTime SonKullanmaTarihi { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} gereklidir!")]

        public int KategoriId { get; set; }
        #endregion


        #region Sayfanın ihtiyacı
        [DisplayName("Birim Fiyatı")]
        public string BirimFiyatiDisplay { get; set; }
        [DisplayName("Son Kullanma Tarihi")]

        public string SonKullanmaTarihiDisplay { get; set; }

        [DisplayName("Kategori")]

        public string KategoriAdiDisplay { get; set; }
        public string Aciklamasi { get; internal set; }
        #endregion
    }
}
