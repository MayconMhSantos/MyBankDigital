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

        public static void ViewPrincial()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
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
                    Console.WriteLine("Opção : 2");
                    break;
                default:
                    ViewPrincial();
                    break;
            }

        }

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
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;

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
            } else {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                ViewCadastro();
            };


        }

        private static void ViewLogin()
        {
            Console.Clear();
            Console.WriteLine("            Login :             ");
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


            if (cpf == cpf)
            {
                if (senha == senha)
                {
                    if (nome == nome)
                    {
                        Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Pessoa não cadastrada");
            };

        }

        private static void ViewWelcome(Pessoa pessoa)
        {
            Console.WriteLine("");
            Console.WriteLine($"Seja Bem Vindo {pessoa.Nome}.");
            Console.WriteLine("");
        }

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

                    break; 
                case 2:  

                    break; 
                case 3:

                    break; 

                case 4:
                    break;

                case 5:
                    ViewPrincial();
                    break;
                default: Console.WriteLine("Opção invalida.");
                    break;
                           
            }
        }

    }
}
