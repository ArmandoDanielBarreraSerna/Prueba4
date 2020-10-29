using Microsoft.EntityFrameworkCore;
using Prueba4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba4.Contexts
{
    public class AppDbContexts: DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options): base(options)
        {

        }

        public DbSet<Producto> Producto { get; set; }
    }
}
