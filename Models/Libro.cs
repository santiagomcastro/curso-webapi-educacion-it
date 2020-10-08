using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Models
{
    public class Libro
    {
        public int Id { get; set; }
        
        [Required]
        public string Titulo { get; set; }
        
        [Required]
        public Autor Autor { get; set; }

    }
}
