using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiGestionDePersone.Modele;

namespace ApiGestionDePersone.Data
{
    public class ApiGestionDePersoneContext : DbContext
    {
        public ApiGestionDePersoneContext (DbContextOptions<ApiGestionDePersoneContext> options)
            : base(options)
        {
        }

        public DbSet<ApiGestionDePersone.Modele.Persone> Persone { get; set; } = default!;
    }
}
