using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriandoAPI.Context;
using CriandoAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CriandoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context) //puxa o bd
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato); // Pós criação do novo contato mostra no header o endereço para visualizar o que foi criado.
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();


            return Ok(contato);
        }

        [HttpGet("TodosContatos")]
        public IActionResult ObterTodosContatos()
        {
            var contatos = _context.Contatos.ToList();
            return Ok(contatos);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult BuscarPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return NoContent();
        }
    }
}