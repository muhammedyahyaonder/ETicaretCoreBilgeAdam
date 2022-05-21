using AppCore.Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface IKategoriService : IService<KategoriModel, Kategori, ETicaretContexts>
    {
         
    }
}
