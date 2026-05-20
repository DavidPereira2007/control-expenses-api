using ControleGastosAPI.Data;
using ControleGastosAPI.Models;
using ControleGastosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGastosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GastosController : ControllerBase
{
    private readonly AppDbContext _context;

    public GastosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet] // Rota para listar todos os gastos

    public async Task<ActionResult<IEnumerable<GastosRespostaDto>>> GetGastos()
    {
        var gastos = await _context.Gastos
            .Select(g => new GastosRespostaDto
            {
                Id = g.Id,
                Descricao = g.Descricao,
                Valor = g.Valor,
                Data = g.Data,
                CategoriaId = g.CategoriaId
            })
            .ToListAsync();
        return Ok(gastos);
    }

    [HttpDelete("{id}")] // Rota para deletar um gasto por ID
    public async Task<ActionResult<int>> DeleteGasto(int id)
    {
        var gasto = await _context.Gastos
            .FirstOrDefaultAsync(g => g.Id == id);
        if (gasto == null)
        {
            return BadRequest("Gasto não encontrado");
        }
        else
        {
            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
            return Ok("Gasto deletado com sucesso");
        }
    }

    [HttpPost] // Rota para criar um novo gasto
    public async Task<ActionResult<GastosRespostaDto>> CriarGasto(
        CriarGastosDto dto)
    {
        var categoria = await _context.Categorias
            .FirstOrDefaultAsync(c => c.Id == dto.CategoriaId);

        if (categoria == null)
        {
            return BadRequest("Categoria não encontrada");
        }

        var gasto = new Gasto
        {
            Descricao = dto.Descricao,
            Valor = dto.Valor,
            Data = DateTime.UtcNow,
            CategoriaId = dto.CategoriaId
            
        };

        _context.Gastos.Add(gasto);
        await _context.SaveChangesAsync();

        var respostaDto = new GastosRespostaDto
        {
            Id = gasto.Id,
            Descricao = gasto.Descricao,
            Valor = gasto.Valor,
            Data = gasto.Data,
            CategoriaId = gasto.CategoriaId
        };

        return CreatedAtAction(
            nameof(GetGastos),
            new { id = gasto.Id },
            respostaDto
            );
    }

}
