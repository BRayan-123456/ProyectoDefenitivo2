using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoDefenitivo2.Models;

namespace ProyectoDefenitivo2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProyectoDefenitivo2.Models.TipoAccesorio> TipoAccesorio { get; set; }
        public DbSet<ProyectoDefenitivo2.Models.Accesorios> Accesorios { get; set; }
        public DbSet<ProyectoDefenitivo2.Models.TipoPersona> TipoPersona { get; set; }
        public DbSet<ProyectoDefenitivo2.Models.Persona> Persona { get; set; }
    }
}
