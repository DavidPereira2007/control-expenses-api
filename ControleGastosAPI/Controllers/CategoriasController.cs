using ControleGastosAPI.Data;
using ControleGastosAPI.Models;
using ControleGastosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ControleGastosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaRespostaDto>>> GetCategorias()
    {
        var categorias = await _context.Categorias
            .Select(c => new CategoriaRespostaDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

        return Ok(categorias);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaRespostaDto>> CriarCategoria(
    CriarCategoriaDto dto
)
    {

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return BadRequest("O nome da categoria é obrigatório.");
        }

        // verificar se a categoria já existe
        var categorias = await _context.Categorias
            .FirstOrDefaultAsync(c => c.Name.ToLower() == dto.Name.ToLower());

        if (categorias != null)
        {
            return BadRequest("Já existe uma categoria com esse nome.");
        }

        var categoria = new Categoria
        {
            Name = dto.Name
        };

        _context.Categorias.Add(categoria);

        await _context.SaveChangesAsync();

        var resposta = new CategoriaRespostaDto
        {
            Id = categoria.Id,
            Name = categoria.Name
        };

        return CreatedAtAction(
            nameof(GetCategorias),
            new { id = categoria.Id },
            resposta
        );
    }
}