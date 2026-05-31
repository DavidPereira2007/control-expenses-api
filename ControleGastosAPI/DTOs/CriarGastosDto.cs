using System.ComponentModel.DataAnnotations;

namespace ControleGastosAPI.DTOs
{
    public class CriarGastosDto
    {
        [StringLength(520,ErrorMessage = "A descrição não pode exceder 520 caracteres")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 10000.00, ErrorMessage = "O preço deve estar entre R$0,01 e R$10.000,00.")]
        public decimal Valor { get; set; }
        public int CategoriaId { get; set; }
    }
}
