using AppCore.Business.Models.Results;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework;
using AppCore.DataAccess.EntityFramework.Bases;
using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Services
{
    public interface IUrunService : IService<UrunModel, Urun, ETicaretContexts>
    {

    }

    public class UrunService : IUrunService
    {
        public RepoBase<Urun, ETicaretContexts> Repo { get; set; } = new Repo<Urun, ETicaretContexts>();
        RepoBase<Urun, ETicaretContexts> IService<UrunModel, Urun, ETicaretContexts>.Repo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Result Add(UrunModel model)
        {
            if (Repo.Query().Any(u => u.Adi.ToLower() == model.Adi.ToLower().Trim()))
                return new ErrorResult("Belirtilen ürün adına sahip kayıt bulunmaktadır!");
            if (model.SonKullanmaTarihi.HasValue && model.SonKullanmaTarihi.Value < DateTime.Today)
                return new ErrorResult("Son kullanma tarihi bugün veya daha sonrası olmalıdır!");
            Urun entity = new Urun()
            {
                Aciklamasi = model.Aciklamasi?.Trim(),
                Adi = model.Adi.Trim(),
                BirimFiyati = model.BirimFiyati.Value,
                KategoriId = model.KategoriId.Value,
                SonKullanmaTarihi = model.SonKullanmaTarihi,
                StokMiktari = model.StokMiktari.Value
            };
            Repo.Add(entity);
            return new SuccessResult("Ürün başarıyla eklendi.");
        }

        public Result Delete(int id)
        {
            Repo.Delete(u => u.Id == id);
            return new SuccessResult("Ürün başarıyla silindi!");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<UrunModel> Query()
        {
            // AutoMapper
            return Repo.Query("Kategori").OrderBy(u => u.Adi).Select(u => new UrunModel()
            {
                Adi = u.Adi,
                Id = u.Id,
                Aciklamasi = u.Aciklamasi,
                BirimFiyati = u.BirimFiyati,
                KategoriId = u.KategoriId,
                SonKullanmaTarihi = u.SonKullanmaTarihi,
                StokMiktari = u.StokMiktari,

                BirimFiyatiDisplay = u.BirimFiyati.ToString("C2", new CultureInfo("tr-TR")), // "en-US"

                SonKullanmaTarihiDisplay = u.SonKullanmaTarihi.HasValue ? u.SonKullanmaTarihi.Value.ToString("yyyy-MM-dd") : "",

                KategoriAdiDisplay = u.Kategori.Adi
            });
        }

        public Result Update(UrunModel model)
        {
            if (Repo.Query().Any(u => u.Adi.ToLower() == model.Adi.ToLower().Trim() && u.Id != model.Id))
                return new ErrorResult("Belirtilen ürün adına sahip kayıt bulunmaktadır!");
            if (model.SonKullanmaTarihi.HasValue && model.SonKullanmaTarihi.Value < DateTime.Today)
                return new ErrorResult("Son kullanma tarihi bugün veya daha sonrası olmalıdır!");
            //Urun entity = Repo.Query().SingleOrDefault(u => u.Id == model.Id);
            Urun entity = Repo.Query(u => u.Id == model.Id).SingleOrDefault();
            entity.Adi = model.Adi.Trim();
            entity.Aciklamasi = model.Aciklamasi?.Trim();
            entity.BirimFiyati = model.BirimFiyati.Value;
            entity.KategoriId = model.KategoriId.Value;
            entity.SonKullanmaTarihi = model.SonKullanmaTarihi;
            entity.StokMiktari = model.StokMiktari.Value;
            Repo.Update(entity);
            return new SuccessResult();
        }
    }
}

