using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversidadWeb.Models;

namespace UniversidadWeb.Data
{
    public class UniversidadDbContext : DbContext
    {
        public DbSet<Universidad> Estudiante { get; set; }

        public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options) : base(options)
        {

        }

    }
}
