using APICaseGM.Data.Mapping;
using APICaseGM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APICaseGM.Data
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
        }


        public DataContext()
            : base("Name=APICase")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CaminhaoMap());
            modelBuilder.Configurations.Add(new CaminhoneiroMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Caminhoneiro> Caminhoneiro { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}