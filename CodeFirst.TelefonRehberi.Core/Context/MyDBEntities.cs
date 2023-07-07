using CodeFirst.TelefonRehberi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.TelefonRehberi.Core.Context
{
    public class MyDBEntities : DbContext
    {
        public MyDBEntities() : base(ConfigurationManager.ConnectionStrings["DbRehberconn"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //tablo isimlerinde s takılarını kaldırır
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<IletisimDetay> IletisimDetay { get; set; }
        public DbSet<IletisimTuru> IletisimTuru { get; set; }
    }
}
