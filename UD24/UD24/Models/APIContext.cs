using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UD24.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext>options):base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Videos> Video { get; set; }


        /* Para Definir Keys 
         * protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientifico>()
                .HasKey(c => c.Dni);
            modelBuilder.Entity<Asignado_a>()
                .HasKey(c => new { c.Cientifico, c.Proyecto });
        }*/
        


    }
}
