using System.ComponentModel.DataAnnotations;

namespace ControleGastosAPI.DTOs
{
    public class CriarCategoriaDto
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")] // Validação para garantir que o nome da categoria seja fornecido
        public string? Name { get; set; }
    }
}
