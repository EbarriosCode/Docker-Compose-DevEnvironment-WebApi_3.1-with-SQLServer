using DockerizingWebApi.Models;
using System.Linq;

namespace DockerizingWebApi.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WebApiDbContext _context)
        {
            #region Datos Iniciales de Artistas    
            // Buscar cualquier artista
            if (_context.Artistas.Any())           
                return;

            var artistas = new Artista[]
            {
                new Artista() { Nombre = "Ricardo Arjona" },
                new Artista() { Nombre = "Luis Miguel"},
                new Artista() { Nombre = "Kalimba" }
            };

            _context.Artistas.AddRange(artistas);
            _context.SaveChanges();
            #endregion Datos Iniciales de Artistas

            #region Datos Iniciales de Albumes
            // Buscar cualquier album
            if (_context.Albumes.Any())
                return;

            var albumes = new Album[]
            {
                new Album()
                {                    
                    ArtistaID = _context.Artistas.FirstOrDefault(a => a.Nombre.Equals("Luis Miguel")).ArtistaID,
                    Titulo = "Romance",
                    Anio = 1991,
                    Precio = 180
                },
                new Album()
                {
                    ArtistaID = _context.Artistas.FirstOrDefault(a => a.Nombre.Equals("Ricardo Arjona")).ArtistaID,
                    Titulo = "Circo Soledad",
                    Anio = 2017,
                    Precio = 190
                },
                new Album()
                {                
                    ArtistaID = _context.Artistas.FirstOrDefault(a => a.Nombre.Equals("Kalimba")).ArtistaID,
                    Titulo = "Aerosoul",
                    Anio = 2004,
                    Precio = 210
                }
            };

            _context.Albumes.AddRange(albumes);
            _context.SaveChanges();
            #endregion Datos Iniciales de Albumes
        }
    }
}
