using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required]
        public string Local { get; set; }

        public string DataEvento { get; set; }

        [Required,
        StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 50 caracteres")]
        public string Tema { get; set; }

        [Required]
        [Range(1,120000, ErrorMessage ="deve estar entre 1 e 120000")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpeg?g|bmp|png)$")]
        public string ImagemURL { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [Display(Name ="E-mail")]
        [EmailAddress(ErrorMessage = "É necessario ser um {0} válido")]
        public string Email { get; set; }

        public int UserId { get; set; }
        public UserDto UserDto { get; set; }

        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> PalestrantesEventos { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
    }
}
