using APICaseGM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APICaseGM.Data.Mapping
{
    public class CaminhaoMap : EntityTypeConfiguration<Caminhao>
    {
        public CaminhaoMap()
        {
            //Primary Key
            this.HasKey(c => c.codigo);

            //Properties
            this.Property(c => c.codigo)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.descricao)
                .IsRequired()
                .HasMaxLength(80);

            //Table & Column Mappings
            this.ToTable("Caminhao");
            this.Property(c => c.codigo).HasColumnName("codigo");
            this.Property(c => c.descricao).HasColumnName("descricao");
        }
    }
}