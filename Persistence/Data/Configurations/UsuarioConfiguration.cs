using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder){
    
              builder.ToTable("usuario");

            builder.Property(p => p.ClaveUsuario)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.CorreoUsuario)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

           builder.HasOne(p => p.Rol)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(p => p.IdRolFK);

            builder.HasOne(p => p.Persona)
                .WithOne(p => p.Usuario)
                 .HasForeignKey<Persona>(d => d.Id);

            builder.HasData(
                new Usuario{Id=1, NombreUsuario="JulianA" , CorreoUsuario="administrador@gmail.com", ClaveUsuario="AQAAAAIAAYagAAAAEJLB6/aRrT6xkqJYUfQxwUt2wY/37H0PPJ4XDNylyx9yk2mGK4ixSJDOn0Mc+KeB6g==", IdRolFK=1, IdPersonaFK = 1},
                new Usuario{Id=2, NombreUsuario="JulianP", CorreoUsuario="profesor@gmail.com", ClaveUsuario="AQAAAAIAAYagAAAAEFSN6Is9/ceIML/0ANwVUWfAvLvM3DvnVik1IjmCZ03xL+ZWXCBPmZ0gHM8ERFflhQ==", IdRolFK=2, IdPersonaFK = 2},
                new Usuario{Id=3, NombreUsuario="JulianE", CorreoUsuario="estudiante@gmail.com", ClaveUsuario="AQAAAAIAAYagAAAAEEL2KHqP09HxnEgi6X7HSyIiBk6TfkY2249D5R/9s/IbMItQdenOd5pS/c6FUVZzzQ==", IdRolFK=3, IdPersonaFK = 3},
                new Usuario{Id=4, NombreUsuario="JulianPa", CorreoUsuario="padre@gmail.com", ClaveUsuario="AQAAAAIAAYagAAAAEOB7D6zemNVt7Es0SiywOv6qCr+Xfl89OmBKONBTSdug1ZpV4nKm+TZPbbJvByxM2w==", IdRolFK=4, IdPersonaFK = 4}
            ); 
   
        } 
    }
}