namespace ControleGastosAPI.DTOs
{
    public class CriarGastosDto
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CategoriaId { get; set; }
    }
}
