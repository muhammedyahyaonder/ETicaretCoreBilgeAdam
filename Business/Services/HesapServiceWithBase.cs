using AppCore.Business.Models.Results;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IHesapService
    {
        Result<KullaniciModel> Giris(KullaniciGirisModel model);
    }
    public class HesapService : IHesapService
    {
        private readonly IKullaniciService _kullaniciservice;

        public HesapService(IKullaniciService kullaniciService)
        {
            _kullaniciservice = kullaniciService;
        }
        public Result<KullaniciModel> Giris(KullaniciGirisModel model)
        {
            KullaniciModel kullanici = _kullaniciservice.Query().SingleOrDefault(k => k.KullaniciAdi == model.KullaniciAdi && k.Sifre ==model.Sifre && k.AktifMi);
            if (kullanici == null)
                return new ErrorResult<KullaniciModel>("Geçersiz kullanıcı adı ve şifre!");
            return new SuccessResult<KullaniciModel>(kullanici);
        }
    }
}
