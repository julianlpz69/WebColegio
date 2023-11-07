using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder){
    
            builder.ToTable("pais");
    
            builder.Property(e => e.NombrePais)
                .HasMaxLength(30);
            
            builder.HasData(
                new Pais {Id=1, NombrePais="Colombia"},
                new Pais {Id=2, NombrePais="Venezuela"}
            );
        }
    }
}