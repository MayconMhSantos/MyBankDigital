using MyBankDigiral.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
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

            Console.WriteLine("    Digite aopção desejada    ");
            Console.WriteLine("==============================");
            Console.WriteLine("| 1 - Criar Conta            |");
            Console.WriteLine("==============================");
            Console.WriteLine("| 2 - Entrar com CPF e Senha |");
            Console.WriteLine("==============================");
            
            string calidandoEntrada = Console.ReadLine();
            if (calidandoEntrada != "1" && calidandoEntrada != "2")
            {
                Console.WriteLine(" ");
                Console.WriteLine("Digite 1 : para Criar Conta ou 2 : Para Acessar uma conta ja cadastrada");
                Thread.Sleep(2000);
                ViewPrincial();
            }

            switch (calidandoEntrada)
            {
                case "1":
                    ViewCadastro();
                    break;
                case "2":
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
            Console.WriteLine("           CADASTRO :         ");
            Console.WriteLine("==============================");
            Console.WriteLine("| Digite Seu Nome :          |");
            Console.WriteLine("==============================");
            string nome = Console.ReadLine();
            Console.WriteLine("==============================");
            Console.WriteLine("| Digite Seu CPF :           |");
            Console.WriteLine("==============================");
            string cpf = Console.ReadLine();
            Console.WriteLine("==============================");
            Console.WriteLine("| Digite sua Senha           |");
            Console.WriteLine("==============================");
            string senha = Console.ReadLine();
            Console.WriteLine("==============================");

            if (cpf != string.Empty && senha.Length > 3)
            {
                if (senha != string.Empty && senha.Length > 3)
                {
                    if (nome != string.Empty && nome.Length > 3)
                    {
                        //Estanciando a Classe Pesoa, para Criar um Objeto Pessoa.

                        ContaCorrente contaCorrente = new ContaCorrente();
                        Pessoa pessoa = new Pessoa();

                        pessoa.SetNome(nome);
                        pessoa.SetCpf(cpf);
                        pessoa.SetSenha(senha);
                        pessoa.Conta = contaCorrente;

                        pessoas.Add(pessoa);
                        Console.Clear();

                        Console.WriteLine("Conta cadastrada com Sucesso!");

                        Thread.Sleep(2000);

                        ViewLogado(pessoa);
                    }
                }
            } 
            else
            {
                Console.WriteLine("O nome Deve conter pelo menos 3 caracteres!");
                Console.WriteLine("O CPF Deve conter pelo menos 3 caracteres!");
                Console.WriteLine("A Senha Deve conter pelo menos 3 caracteres!");
                Thread.Sleep(2000);
                Console.Clear();
                ViewCadastro();
            };


        }

        //-------------------View LOGIN--------------------
        private static void ViewLogin()
        {
            string auxx = "";
            Console.Clear();
            Console.WriteLine("==============================      ");
            Console.WriteLine("| Digite Seu CPF :           |      ");
            string cpf = Console.ReadLine();
            Console.WriteLine("==============================      ");
            Console.WriteLine("| Digite sua Senha           |      ");
            string senha = Console.ReadLine();
            Console.WriteLine("==============================      ");

            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa != null)
            {
                Console.WriteLine("Login realizado com Sucess!");

                Thread.Sleep(2000);

                ViewWelcome(pessoa);
                ViewLogado(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("                  CADASTRO NÃO ENCONTRADO            ");
                Console.WriteLine(" ");
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
            string dadosCliente = $"{pessoa.Nome} | Banco : {pessoa.Conta.GetNomeBanco()} | Numero da Conta : {pessoa.Conta.GetNumeroConta()} |Agencia : {pessoa.Conta.GetNumeroAgencia()}";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Seja Bem Vindo {dadosCliente}.");
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

            Console.WriteLine("======================================");
            Console.WriteLine("    Digite o Valor do Deposito : R$");
            Console.WriteLine("======================================");
            double Vdeposito = double.Parse(Console.ReadLine());

            if (Vdeposito != null)
            {
                pessoa.Conta.Depositar(Vdeposito);

                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("     Deposito realizado com Sucesso!  ");
                Console.WriteLine("======================================");
                Console.WriteLine(" ");
                Console.WriteLine("======================================");
                Console.WriteLine("      1 - Tela de Menu               |");
                Console.WriteLine("======================================");
                Console.WriteLine("      2 - Sair                       |");
                Console.WriteLine("======================================");

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
                Console.Clear();
                Console.WriteLine("=======================================================");
                Console.WriteLine("   Valor informado não valido, Tente novamente!");
                Console.WriteLine("=======================================================");
                Thread.Sleep(1000);
                ViewDeposito(pessoa);
            }
        }

        //----------------View SAQUE---------------
        private static void ViewSaque(Pessoa pessoa)
        {
            Console.Clear();
            ViewWelcome(pessoa);

            Console.WriteLine("======================================");
            Console.WriteLine("    Digite o Valor do Saque : R$");
            Console.WriteLine("======================================");
            double Vsaque = double.Parse(Console.ReadLine());

            if (Vsaque != null)
            {
                if (pessoa.Conta.Sacar(Vsaque) == false)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("=====================================================================================================");
                    Console.WriteLine($"Saldo insuficiente para saque. Seu saldo é de R${pessoa.Conta.ConsultaSaldo()}.");
                    Console.WriteLine("=====================================================================================================");
                    Thread.Sleep(2000);
                    ViewSaque(pessoa);

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("======================================");
                    Console.WriteLine("     Saque realizado com Sucesso!");
                    Console.WriteLine("======================================");
                    Console.WriteLine(" ");
                    Console.WriteLine("======================================");
                    Console.WriteLine("      1 - Tela de Menu               |");
                    Console.WriteLine("======================================");
                    Console.WriteLine("      2 - Sair                       |");
                    Console.WriteLine("======================================");

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
                Console.Clear();
                Console.WriteLine("=======================================================");
                Console.WriteLine("   Valor informado não valido, Tente novamente!");
                Console.WriteLine("=======================================================");
                Thread.Sleep(1000);
                ViewSaque(pessoa);
            }

        }

        //----------------View EXTRATO---------------
        private static void ViewExtrato(Pessoa pessoa)
        {
            ViewWelcome(pessoa);



            if (pessoa.Conta.Extrato().Any())
            {
                double total = pessoa.Conta.Extrato().Sum(x => x.ValorSaldo);

                //TIPO : Extrato=extrato buscando da variavel pessoa.conta.extrato 
                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine(" | Nome : " + pessoa.Nome);
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine(" | CPF : " + pessoa.CPF);
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine(" | BANCO : " + pessoa.Conta.GetNomeBanco());
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine(" | NUMERO DA CONTA : " + pessoa.Conta.GetNumeroConta());
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine(" | AGENCIA : " + pessoa.Conta.GetNumeroAgencia());
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine($" | Tipo de Movimentação : {extrato.Data.ToString("dd/mm/yyyy HH:mm:ss")}");
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine($" | Tipo de Movimentação : {extrato.Descricao}");
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine($" | Tipo de Movimentação : {extrato.ValorSaldo}");
                    Console.WriteLine(" =====================================================");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆▆");
                    Console.WriteLine(" ");
                }
                Console.WriteLine("=====================================================");
                Console.WriteLine($"| SUB TOTAL :{total}                                 ");
                Console.WriteLine("=====================================================");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("==============================");
                Console.WriteLine("|Não há Extrato a ser Ixibido ");
                Console.WriteLine("==============================");
                Console.WriteLine(" ");
            }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("============================== ");
                Console.WriteLine("| 1 - Tela de Menu           | ");
                Console.WriteLine("============================== ");
                Console.WriteLine("| 2 - Sair do sistema        | ");
                Console.WriteLine("============================== ");

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
                Console.WriteLine("==========================================");
                Console.WriteLine($"Seu Saldo é de : R${pessoa.Conta.ConsultaSaldo()} ");
                Console.WriteLine("==========================================");
                Console.WriteLine(" ");
                Console.WriteLine("==========================================");
                Console.WriteLine("| 1 - Tela de Menu                       | ");
                Console.WriteLine("==========================================");
                Console.WriteLine("| 2 - Sair do sistema                    | ");
                Console.WriteLine("==========================================");

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

