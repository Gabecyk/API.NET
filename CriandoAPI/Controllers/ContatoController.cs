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
            return Ok(contato);
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
    }
}