using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankDigiral.Model
{
    public abstract class Banco
    {
        public Banco() 
        {
            this.NomeBanco = "Banco do Brasil";
            this.CodigoBanco = "0707";
        }

        public string NomeBanco { get; protected set; }
        public string CodigoBanco { get; protected set; }
    }
}
