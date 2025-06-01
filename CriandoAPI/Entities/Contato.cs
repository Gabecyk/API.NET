using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriandoAPI.Entities
{
    public class Contato // Vai representar uma tabela no banco de dados
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}