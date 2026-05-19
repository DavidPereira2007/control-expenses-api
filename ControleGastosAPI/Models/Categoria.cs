namespace ControleGastosAPI.Models
{
        public class Categoria
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Gasto> Gastos { get; set; } = new();
        }
}
