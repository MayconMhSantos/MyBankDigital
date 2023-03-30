using MyBankDigiral.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankDigiral.Model
{
    public abstract class Conta : Banco, IConta
    {

        public Conta() 
        {
            this.NumeroConta = "0001";
            Conta.NumeroDaContaSequencial++;
        }

        public double Saldo { get; protected set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; protected set; }


        //Static Não faz mais parte do Objeto e Sim da Classe então para chamar utilise "CONTA.Numero....."
        public static int NumeroDaContaSequencial { get; private set; }

        //-------------------Methodos--CAIXA--------------------------

        public bool Sacar(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;

            this.Saldo -= valor;
            return true;
        }
        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }




        //-------------CLASS-----BANCO----------------------------


        public string GetNomeBanco()
        {
            return this.NomeBanco;
        }

        public string GetCodigoBanco()
        {
            return this.CodigoBanco;
        }



    }
}
