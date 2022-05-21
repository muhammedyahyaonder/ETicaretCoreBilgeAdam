using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Urun : RecordBase
    {
        [Required]
        [StringLength(200)]

        public string Adi { get; set; }
        [StringLength(500)]
        public string Aciklamasi { get; set; }
        public double BirimFiyati { get; set; }
        public int StokMiktari { get; set; }
        public DateTime? SonKullanmaTarihi { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
