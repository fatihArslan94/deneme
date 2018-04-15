using SiparisTakip.Dal.Abstract.StokDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip.Entity.Models;
using SiparisTakip.Dal.Concrete.EntityFramework.Context;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;

namespace SiparisTakip.Dal.Concrete.EntityFramework.Repository
{
    public class EfStokRepository : IStokDal
    {
        SiparisTakipContext SiparisTakipContext = new SiparisTakipContext();
        public Stok Getir(int id)
        {
            return SiparisTakipContext.Stok.AsNoTracking().Where(x=>x.StokID==id).SingleOrDefault();
        }

        public int Guncelle(Stok entity)
        {
            SiparisTakipContext.Stok.AddOrUpdate(entity);
            return SiparisTakipContext.SaveChanges();
        }

        public Stok Kaydet(Stok entity)
        {
            SiparisTakipContext.Stok.Add(entity);
            SiparisTakipContext.SaveChanges();
            return entity;
        }

        public List<Stok> Listele()
        {
            return SiparisTakipContext.Stok.AsNoTracking().ToList();
        }

        public List<Stok> Listele(Expression<Func<Stok, bool>> predicate)
        {
            return SiparisTakipContext.Stok.Where(predicate).ToList();
        }

        public bool Sil(int id)
        {
            //var stk= SiparisTakipContext.Stok.AsNoTracking().Where(x => x.StokID == id).SingleOrDefault();
            var stok = Getir(id);
            return Sil(stok);
        }


        public bool Sil(Stok entity)
        {
            SiparisTakipContext.Stok.Remove(entity);
            return SiparisTakipContext.SaveChanges()>0;
        }
    }
}
