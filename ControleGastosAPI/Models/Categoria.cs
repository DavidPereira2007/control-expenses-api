using System.ComponentModel.DataAnnotations;

namespace ControleGastosAPI.Models
{
        public class Categoria
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
             public string? Name { get; set; }
            public List<Gasto> Gastos { get; set; } = new();
        }
}
