using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder){
    
        

           builder.HasKey(p => p.Id);

        builder.Property(p => p.Nombres)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Apellidos)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.CorreoElectronico)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Documento)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(p => p.Telefono)
            .HasMaxLength(15);

        builder.Property(p => p.FechaNacimiento)
            .IsRequired();

        builder.Property(p => p.IdTipoDocumentoFK)
            .IsRequired();

        builder.HasOne(p => p.Direccion)
            .WithOne(d => d.Persona)
            .HasForeignKey<Direccion>(d => d.Id);
            

        builder.HasData(new Persona
        {
            Id = 1,
            Nombres = "Nombre Ejemplo",
            Apellidos = "Apellido Ejemplo",
            CorreoElectronico = "persona@example.com",
            Documento = "123456789",
            Telefono = "1234567890",
            FechaNacimiento = new DateOnly(2022, 10, 10),
            IdTipoDocumentoFK = 1
        },
        new Persona
        {
            Id = 2,
            Nombres = "Nombre Ejemplo",
            Apellidos = "Apellido Ejemplo",
            CorreoElectronico = "persona@example.com",
            Documento = "123456789",
            Telefono = "1234567890",
            FechaNacimiento = new DateOnly(2022, 10, 10),
            IdTipoDocumentoFK = 1
        },
        new Persona
        {
            Id = 3,
            Nombres = "Nombre Ejemplo",
            Apellidos = "Apellido Ejemplo",
            CorreoElectronico = "persona@example.com",
            Documento = "123456789",
            Telefono = "1234567890",
            FechaNacimiento = new DateOnly(2022, 10, 10),
            IdTipoDocumentoFK = 1
        },
        new Persona
        {
            Id = 4,
            Nombres = "Nombre Ejemplo",
            Apellidos = "Apellido Ejemplo",
            CorreoElectronico = "persona@example.com",
            Documento = "123456789",
            Telefono = "1234567890",
            FechaNacimiento = new DateOnly(2022, 10, 10),
            IdTipoDocumentoFK = 1
        });

            builder.HasOne(p => p.TipoDocumento)
                .WithMany(p => p.Personas)
                .HasForeignKey(p => p.IdTipoDocumentoFK);


            builder.HasOne(p => p.Estudiante)
                .WithOne(p => p.Persona)
                 .HasForeignKey<Estudiante>(d => d.Id);
        }
    }
}