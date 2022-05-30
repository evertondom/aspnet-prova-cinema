using System.ComponentModel.DataAnnotations;
namespace Cinema.Models
{
    public class Filme
    {
        [Key]
        public int FilmeId { get; set; }

        [Display(Name = "Nome do Filme")]
        [Required(ErrorMessage ="Nome do filme é obrigatório")]
        [StringLength(60, MinimumLength =2, ErrorMessage ="Nome do Filme inválido")]
        public string NomeFilme { get; set; }

        [Display(Name ="Gênero do Filme")]
        [Required(ErrorMessage = "Categoria do filme é obrigatório")]
        [StringLength(20, MinimumLength = 5, ErrorMessage ="Nome da Categoria inválido")]
        public string CategoriaFilme { get; set; }

        [Display(Name = "Sinopse do Filme")]
        [Required(ErrorMessage = "Sinopse é obrigatório")]
        [StringLength(300, MinimumLength = 50, ErrorMessage ="Sinopse inválida")]
        public string Sinopse { get; set; }
    }
}
