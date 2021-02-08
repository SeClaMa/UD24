using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UD24_Ej3.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        { }
            public DbSet<Cientificos> Cientifico { get; set; }
            
            public DbSet<Proyecto> Proyectos { get; set; }

            public DbSet<Asignado_A> Asignado_As { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientificos>()
                .HasKey(c => c.DNI);
            modelBuilder.Entity<Asignado_A>()
                .HasKey(c => new { c.Cientificos, c.Proyectos });
        }
    }

    }
    

