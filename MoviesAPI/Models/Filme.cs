using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Título é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Diretor é obrigatorio")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Genero tem que ter no máximo 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "Duração deve ter no minimo 1 min e no máximo 600 minutos")]
        public int Duracao { get; set; }

    }
}