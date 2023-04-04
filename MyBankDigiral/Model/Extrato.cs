using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankDigiral.Model
{
    public class Extrato
    {
        public Extrato(DateTime data, string descricao, double ValorSaldo)
        {
            this.Data = data;
            this.Descricao  = descricao;
            this.ValorSaldo = ValorSaldo;
        }

    public DateTime  Data {get; private set; }
    public string Descricao { get;  private set; }
    public double ValorSaldo { get;  private set; }
    

    }
}
