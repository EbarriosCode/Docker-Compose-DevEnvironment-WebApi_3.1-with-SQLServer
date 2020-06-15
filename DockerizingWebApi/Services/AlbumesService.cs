using DockerizingWebApi.DataContext;
using DockerizingWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DockerizingWebApi.Services
{
    public interface IAlbumesService
    {
        Task<List<Album>> GetAlbumesAsync();
        Task<List<Artista>> GetArtistasAsync();
    }
    public class AlbumesService : IAlbumesService
    {
        private readonly WebApiDbContext _context;
        public AlbumesService(WebApiDbContext context) => _context = context;

        public async Task<List<Album>> GetAlbumesAsync()
        {
            var albumes = new List<Album>();

            try
            {
                albumes = await _context.Albumes.Include(a => a.Artista).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return albumes;
        }

        public async Task<List<Artista>> GetArtistasAsync()
        {
            var artistas = new List<Artista>();

            try
            {
                artistas = await _context.Artistas.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return artistas;
        }
    }
}
