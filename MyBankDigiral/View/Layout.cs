using MyBankDigiral.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyBankDigiral.View
{
    internal class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        private static int opcao = 0;
        private static int aux = 0;  

        //---------------- View PRINCIPAL------------------
        public static void ViewPrincial()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("            Digite aopção desejada             ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | 1 - Criar Conta            |      ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | 2 - Entrar com CPF e Senha |      ");
            Console.WriteLine("            ==============================      ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ViewCadastro();
                    break;
                case 2:
                    ViewLogin();
                    break;
                default:
                    ViewPrincial();
                    break;
            }

        }

        //-----------------View CRIAR CONTA---------------
        private static void ViewCadastro()
        {
            Console.Clear();
            Console.WriteLine("            Cadastro :             ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | Digite Seu Nome :          |      ");
            string nome = Console.ReadLine();
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | Digite Seu CPF :           |      ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | Digite sua Senha           |      ");
            string senha = Console.ReadLine();
            Console.WriteLine("            ==============================      ");

            if (cpf != string.Empty)
            {
                if (senha != string.Empty)
                {
                    if (nome != string.Empty)
                    {
                        //ViewPrincial();

                        ContaCorrente contaCorrente = new ContaCorrente();

                        Pessoa pessoa = new Pessoa();

                        pessoa.SetNome(nome);
                        pessoa.SetCpf(cpf);
                        pessoa.SetSenha(senha);
                        pessoa.Conta = contaCorrente;

                        pessoas.Add(pessoa);
                        Console.Clear();

                        Console.WriteLine("Conta cadastrada com Sucesso!");
                        ViewLogado(pessoa);
                    }
                }
            } else 
            {
                ViewCadastro();
            };


        }

        //-------------------View LOGIN--------------------
        private static void ViewLogin()
        {
            Console.Clear();
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | Digite Seu CPF :           |      ");
            string cpf = Console.ReadLine();
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | Digite sua Senha           |      ");
            string senha = Console.ReadLine();
            Console.WriteLine("            ==============================      ");

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if(pessoa != null)
            {
                ViewWelcome(pessoa);
                ViewLogado(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("                  CADASTRO NÃO ENCONTRADO            ");
                Console.WriteLine("            ===================================      ");
                Console.WriteLine("            | 1 - Voltar para Tela Principal  |      ");
                Console.WriteLine("            ===================================      ");
                Console.WriteLine("            | 2 - Tenatar novamente           |      ");
                Console.WriteLine("            ===================================      ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ViewPrincial();
                        break;
                    case 2:
                        Console.Clear();
                        ViewLogin();
                        break;
                    default:
                        Console.WriteLine("Opção digitada invalida!");
                        break;
                }
            };

        }

        //------------------View BEM VINDO---------------
        private static void ViewWelcome(Pessoa pessoa)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Seja Bem Vindo {pessoa.Nome}.");
            Console.WriteLine("");
        }
        //-------------------View LOGADO----------------
        private static void ViewLogado(Pessoa pessoa)
        {
  
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            ViewWelcome(pessoa);

            Console.WriteLine("            Digite aopção desejada             ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | 1 - Realizar um Deposito   |      ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | 2 - Realizar um Saque      |      ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | 3 - Consultar Saldo        |      ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | 4 - Extrato                |      ");
            Console.WriteLine("            ==============================      ");
            Console.WriteLine("            | 5 - Sair                   |      ");
            Console.WriteLine("            ==============================      ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao) 
            {
                case 1:
                    ViewDeposito(pessoa);
                    break; 
                case 2:  
                    ViewSaque(pessoa);
                    break; 
                case 3:
                    ViewConsultarSaldo(pessoa);
                    break; 

                case 4:
                    ViewExtrato(pessoa);
                    break;
                case 5:
                    ViewPrincial();
                    break;
                default: Console.WriteLine("Opção invalida.");
                    break;
                           
            }
        }

        //----------------View DEPOSITO---------------
        private static void ViewDeposito(Pessoa pessoa)
        {
            Console.Clear();
            ViewWelcome(pessoa);
            Console.WriteLine("Digite o Valor do Deposito : ");
            int Vdeposito = int.Parse(Console.ReadLine());

            if (Vdeposito != null)
            {
                pessoa.Conta.Depositar(Vdeposito);
                Console.WriteLine("            Valor depositado com Sucesso!       ");
                Console.WriteLine("            ==============================      ");
                Console.WriteLine("            | 1 - Voltar ao Menu         |      ");
                Console.WriteLine("            ==============================      ");
                Console.WriteLine("            | 2 - Sair                   |      ");
                Console.WriteLine("            ==============================      ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ViewLogado(pessoa);
                        break;
                    case 2:
                        ViewPrincial();
                        break;
                    default:
                        Console.WriteLine("Opção digitada invalida!");
                        break;
                }

            }
            else 
            { 
                Console.WriteLine("Valor informado não valido!"); 
            }



        }

        //----------------View SAQUE---------------
        private static void ViewSaque(Pessoa pessoa)
        {
            Console.Clear();
            ViewWelcome(pessoa);
            if(aux != 0)
            {
                Console.WriteLine($"Saldo insuficiente para saque. Seu saldo é de {pessoa.Conta.ConsultaSaldo()}");
            }
            Console.WriteLine("Digite o Valor do Saque : ");

             int Vsaque = int.Parse(Console.ReadLine());

            if (Vsaque != null)
            {
                if(pessoa.Conta.Sacar(Vsaque) == false)
                {
                    aux++;
                    ViewSaque(pessoa);

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Saque realizado com Sucesso!");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("          ==============================        ");
                    Console.WriteLine("          | 1 - Tela de Menu           |        ");
                    Console.WriteLine("          ==============================        ");
                    Console.WriteLine("          | 2 - SAIR                   |        ");
                    Console.WriteLine("          ==============================        ");
                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            ViewLogado(pessoa);
                            break;
                        case 2:
                            ViewPrincial();
                            break;
                        default: 
                            Console.WriteLine("Opção digitada invalida!");
                            break;                            
                    }
                }
            }
            else
            {
                Console.WriteLine("Valor informado não valido!");
            }

        }

        //----------------View EXTRATO---------------
        private static void ViewExtrato(Pessoa pessoa)
        {
            ViewWelcome(pessoa);

            Console.WriteLine("            ==============================");
            Console.WriteLine("            | Nome : " + pessoa.Nome );
            Console.WriteLine("            ==============================");
            Console.WriteLine("            | CPF : " + pessoa.CPF );
            Console.WriteLine("            ==============================");
            Console.WriteLine("            | BANCO : " + pessoa.Conta.GetNomeBanco());
            Console.WriteLine("            ==============================");
            Console.WriteLine("            | NUMERO DA CONTA : " + pessoa.Conta.GetNumeroConta());
            Console.WriteLine("            ==============================");
            Console.WriteLine("            | AGENCIA : " + pessoa.Conta.GetNumeroAgencia());
            Console.WriteLine("            ==============================");
            Console.WriteLine("            | SEU SALDO : " + pessoa.Conta.ConsultaSaldo());
            Console.WriteLine("            ==============================");


            Console.WriteLine("            ============================== ");
            Console.WriteLine("            | 1 - Tela de Menu           | ");
            Console.WriteLine("            ============================== ");
            Console.WriteLine("            | 2 - Sair do sistema        | ");
            Console.WriteLine("            ============================== ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ViewLogado(pessoa);
                    break;
                case 2:
                    ViewPrincial();
                    break;
                default:
                    Console.WriteLine("Opção digitada invalida!");
                    break;
            }
        }

        //----------------View CONSULTAR SALDO---------------
        private static void ViewConsultarSaldo(Pessoa pessoa)
        {

            ViewWelcome(pessoa);    
            Console.WriteLine(              $"Seu Saldo é de : R${pessoa.Conta.ConsultaSaldo()} ");
            Console.WriteLine(" ");
            Console.WriteLine("            ============================== ");
            Console.WriteLine("            | 1 - Tela de Menu           | ");
            Console.WriteLine("            ============================== ");
            Console.WriteLine("            | 2 - Sair do sistema        | ");
            Console.WriteLine("            ============================== ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ViewLogado(pessoa);
                    break;
                case 2:
                    ViewPrincial();
                    break;
                default:
                    Console.WriteLine("Opção digitada invalida!");
                    break;
            }



        }



    }
}
