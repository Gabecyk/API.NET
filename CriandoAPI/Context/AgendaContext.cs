using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriandoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CriandoAPI.Context
{
    public class AgendaContext : DbContext // Representa o banco de dados, no qual será usado
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; } //DbSet para representar tabela
        

    }
}