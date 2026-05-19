using Microsoft.EntityFrameworkCore;
using ControleGastosAPI.Models;

namespace ControleGastosAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Gasto> Gastos { get; set; }
}