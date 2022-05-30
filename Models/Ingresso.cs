using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Ingresso
    {
        public int IngressoId { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [Display(Name ="Escolha o Cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name ="Escolha o Filme")]
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name ="Número da Sala")]
        public int SessaoId { get; set; }

        [Display(Name ="Escolha a hora da sessão")]
        public int HoraId { get; set; }

        [Display(Name ="Escolha a opção  de ingresso")]
        public int TipoIngressoId { get; set; }

        [Display(Name ="Escolha seu Assento")]
        public int AssentoId { get; set; }


        public Cine Cinema { get; set; }
        public Filme Filme { get; set; }
        public Sessao Sessao { get; set; }
        public Hora Hora { get; set; }
        public TipoIngresso TipoIngresso { get; set; }
        public Assento Assento { get; set; }
    }
}
