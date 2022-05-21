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
    public interface KullaniciService : IService<KullaniciModel, Kullanici, ETicaretContexts>
    {
    }
    public class KullaniciService : IKullaniciService
    {
        public RepoBase<Kullanici, ETicaretContexts> Repo { get; set; } = new Repo<Kullanici, ETicaretContexts();

        public Result Add(KullaniciModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Repo.Dispose();
        }
        public IQueryable<KullaniciModel> Query()
        {
            return Repo.Query().Select(e => new KullaniciModel()
            {
                AktifMi = e.AktifMi,
                Id = e.Id,
                KullaniciAdi = e.KullaniciAdi,
                Rolİd = e.RolId,
                Sifre = e.Sifre,
            });
        }
        public Result Update(KullaniciModel model)
        {
            throw new NotImplementedException();
        }
    }
}
