using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost] //padrão de criar novo recurso no sistema
        public IActionResult AdcionarFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorID), new { id = filme.Id }, filme);
        }
        [HttpGet] //padrão para recuperar recursos do sistema
        public IActionResult RecuperarFilmes()
        {
            return Ok(_context.Filmes);
        }
        [HttpGet("{id}")]//padrão para recuperar recursos do sistema com parametro
        public IActionResult RecuperaFilmePorID(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(obj => obj.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
        [HttpPut("{id}")]//padrão para atualizar recursos do sistema com parametro
        public IActionResult AtualizaFilme(int id, [FromBody] Filme updateFilme)
        {
            var filme = _context.Filmes.FirstOrDefault(obj => obj.Id == id);
            if (filme != null)
            {
                filme.Titulo = updateFilme.Titulo;
                filme.Genero = updateFilme.Genero;
                filme.Diretor = updateFilme.Diretor;
                filme.Duracao = updateFilme.Duracao;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]//Metodo para deletar
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(obj => obj.Id == id);
            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();

        }
    }
}