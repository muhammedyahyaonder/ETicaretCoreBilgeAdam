using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class ETicaretContexts : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<KullaniciDetayi> KullanicilarDetaylari { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder)
        {
            string connectionString = "server=.;database=BA_ETicaretCore8523;user id =sa;password=123;multipleactiveresultsets = true;"
                OptionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Urun>()
            .HasOne(urun => urun.Kategori)
                .WithMany(kategori => kategori.Urunler)
                .HasForeignKey(urun => urun.KategoriId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Kullanici>()
                //.ToTable("ETicaretKullanicilar")
                .HasOne(k => k.Rol)
                .WithMany(r => r.Kullanicilar)
                .HasForeignKey(k => k.RolId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KullaniciDetayi>()
                .HasOne(x => x.Kullanici)
                .WithOne(x => x.KullaniciDetayi)
                .HasForeignKey<KullaniciDetayi>(x => x.KullaniciId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
