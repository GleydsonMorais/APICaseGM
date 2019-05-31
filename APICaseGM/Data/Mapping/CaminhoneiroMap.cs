using APICaseGM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APICaseGM.Data.Mapping
{
    public class CaminhoneiroMap : EntityTypeConfiguration<Caminhoneiro>
    {
        public CaminhoneiroMap()
        {
            //Primary Key
            this.HasKey(c => c.idCaminhoneiro);

            //Properties
            this.Property(c => c.idCaminhoneiro)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.nome)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(c => c.idade)
                .IsRequired();

            this.Property(c => c.sexo)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(c => c.possuiVeiculo)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(c => c.tipoCNH)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(c => c.carregado)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(c => c.caminhao)
                .IsRequired();

            this.Property(c => c.dataChegada)
                .IsRequired();

            this.Property(c => c.origem)
                .HasMaxLength(300);

            this.Property(c => c.destino)
                .HasMaxLength(300);

            //Table & Column Mappings
            this.ToTable("Caminhoneiro");
            this.Property(c => c.idCaminhoneiro).HasColumnName("idCaminhoneiro");
            this.Property(c => c.nome).HasColumnName("nome");
            this.Property(c => c.idade).HasColumnName("idade");
            this.Property(c => c.sexo).HasColumnName("sexo");
            this.Property(c => c.possuiVeiculo).HasColumnName("possuiVeiculo");
            this.Property(c => c.tipoCNH).HasColumnName("tipoCNH");
            this.Property(c => c.carregado).HasColumnName("carregado");
            this.Property(c => c.caminhao).HasColumnName("caminhao");
            this.Property(c => c.dataChegada).HasColumnName("dataChegada");
            this.Property(c => c.origem).HasColumnName("origem");
            this.Property(c => c.destino).HasColumnName("destino");

            //Relationships
            this.HasRequired(c => c.CaminhaoCaminhoneiro)
                .WithMany(c => c.CaminhoneiroCaminhao)
                .HasForeignKey(fk => fk.caminhao);
        }
    }
}