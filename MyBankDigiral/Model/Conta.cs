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
            this.NumeroAgencia = "7070-15";
            Conta.NumeroDaContaSequencial++;

            // toda vez que passa no construtora ira criar uma lista de movimentação para nossa conta.
            this.Movimentacoes = new List<Extrato>();
        }

        public double Saldo { get; protected set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; protected set; }

        //Static Não faz mais parte do Objeto e Sim da Classe então para chamar utilise "CONTA.Numero....."
        public static int NumeroDaContaSequencial { get; private set; }


        // Não vou inserir Get and Set, póis apenas esta classe alterará este Atributo LISTA.
        private List<Extrato> Movimentacoes;



        //----------Method SACAR-------------
        public bool Sacar(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;

            //Pegando Hora Atual
            DateTime dataAtual = DateTime.Now;
            // inserindo dentro da LISTA Movime... um novo objeto Extrato intanciando e inserindo na Lista Moviment....
            this.Movimentacoes.Add(new Extrato(dataAtual, "SAQUE", -valor));   

            this.Saldo -= valor;
            return true;
        }

        //----------Method DEPOSITAR-------------
        public void Depositar(double valor)
        {
            //Pegando Hora Atual
            DateTime dataAtual = DateTime.Now;
            // inserindo dentro da LISTA Movime... um novo objeto Extrato intanciando e inserindo na Lista Moviment....
            this.Movimentacoes.Add(new Extrato(dataAtual, "DEPOSITO", valor));
            this.Saldo += valor;
        }

        //------Method CONSULTAR SALDO-------------
        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        //-------Method NUMERO AGENCIA-------------
        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        //------Method NUMERO CONTA-------------
        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }

        //------Method NOME BANCO-------------
        public string GetNomeBanco()
        {
            return this.NomeBanco;
        }

        //------Method CODIGO DO BANCO-------------
        public string GetCodigoBanco()
        {
            return this.CodigoBanco;
        }

        public List<Extrato> Extrato()
        {
            return this.Movimentacoes;
        }
    }
}
