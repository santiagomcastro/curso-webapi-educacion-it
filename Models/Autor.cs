
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Models
{
    public class Autor
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        public IEnumerable<Libro> Libro { get; set; }
    }
}
