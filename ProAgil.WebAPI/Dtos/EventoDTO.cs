using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        [Required(ErrorMessage = "Campo tema é requerido!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tema deve ser entre 4 e 50 caracteres")]
        public string Tema { get; set; }

        [Range(10, 120000, ErrorMessage = "Quantidade de espectadores deve estar entre 1 e 120000")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }

        [Required]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public List<LoteDTO> Lotes { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }
        public List<PalestranteDTO> Palestrantes { get; set; }
    }
}