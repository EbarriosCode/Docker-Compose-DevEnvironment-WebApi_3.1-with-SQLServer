using DockerizingWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerizingWebApi.DataContext
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext() { }

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albumes { get; set; }
        public DbSet<Artista> Artistas { get; set; }        
    }
}
