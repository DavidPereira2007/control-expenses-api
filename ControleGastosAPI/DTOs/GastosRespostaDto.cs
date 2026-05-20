namespace ControleGastosAPI.DTOs
{
    public class GastosRespostaDto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
    }
}
