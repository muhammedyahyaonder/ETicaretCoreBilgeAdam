using AppCore.Business.Models.Results;
using AppCore.DataAccess.EntityFramework;
using AppCore.Business.Services.Bases;
using AppCore.DataAccess.EntityFramework.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Contexts;
using Business.Services.Bases;

namespace Business.Services
{
    public class KategoriService : IKategoriService
    {
        public RepoBase<Kategori, ETicaretContexts> Repo { get; set; } = new Repo<Kategori, ETicaretContexts>();

        public Result Add(KategoriModel model)
        {
            if (Repo.Query().Any(KategoriModel => Kategori.Adi.ToUpper() == model.Adi.ToUpper().Trim()))
                return new ErrorResult("Girdiğiniz kategori adına sahip kayıt bulunmaktadırQ");

            Kategori entity = new Kategori()
            {
                Adi = model.Adi.Trim(),
                Aciklamasi = model.Aciklamasi.Trim()
            };
            Repo.Add(entity);
            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            Kategori entity = Repo.Query(k => k.id == id, "Urunler").SingleOrDefault();
            if (entity.Urunler != null && entity.Urunler.Count > 0)
            {
                return new ErrorResult("Kategori silinemez çünkü ilişkili ürünler bulunmaktadır!");
            }
            Repo.Delete(entity);
            return new SuccessResult("Kategori başarıyla silindi.");
        }

        public void Dispose()
        {
            Repo.Dispose();
        }

        public IQueryable<KategoriModel> Query()
        {
            IQueryable<KategoriModel> query = Repo.Query("Urunler").OrderBy(k => k.Adi).Select(k => new KategoriModel()
            {
                Id = k.Id,
                Adi = k.Adi,
                Aciklamasi = k.Aciklamasi,
                UrunSayisiDisplay = k.Urunler.Count
            });
            return query;
        }

        public Result Update(KategoriModel model)
        {
            if (Repo.Query().Any(kategori => kategori.Adi.ToUpper() == model.Adi.ToUpper().Trim() && kategori.Id != model.Id))
                return new ErrorResult("Girdiğiniz kategori adına sahip kayıt bulunmaktadır!");
            Kategori entity = Repo.Query().SingleOrDefault(kategori => kategori.Id == model.Id);
            entity.Adi = model.Adi.Trim();
            entity.Aciklamasi = model.Aciklamasi.Trim();
            Repo.Update(entity);
            return new SuccessResult("Kategori başarıyla eklendi.");
        }
    }
}
