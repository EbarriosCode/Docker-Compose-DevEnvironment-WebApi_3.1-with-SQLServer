using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DockerizingWebApi.Models
{
    [Table("Artista")]
    public class Artista
    {
        [Key]
        public int ArtistaID { get; set; }
        public string Nombre { get; set; }
    }
}
