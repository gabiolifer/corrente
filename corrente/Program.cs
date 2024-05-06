using corrente;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


CCorrente conta = new CCorrente("11234", 500);

namespace corrente
{
    public class Program
    {
        public List<CCorrente> contas=new List<CCorrente>();

        public void Main(string[] args)
        {
            string? op;
            do
            {
                Console.WriteLine("========Menu========");
                Console.WriteLine("1. Acesso Administrativo");
                Console.WriteLine("2. Caixa Eletronico");
                Console.WriteLine("3. Sair");
                Console.Write("escolha uma opcao: ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "1": MenuAcessoAdministrativo(); break;
                    case "2":
                        Console.WriteLine("digite o numero da conta: ");
                        string? numeroConta = Console.ReadLine();

                        if (contas.Contains(numeroConta))
                        {
                            MenuCaixaEletronico(); break;
                        }
                        else
                        {
                            Console.WriteLine("a conta não existe");
                            break;
                        }
                    case "3":
                        Console.WriteLine("programa encerrado.");
                        break;
                    default: Console.WriteLine("invalido, redigite."); break;
                }

                public void MenuAcessoAdministrativo()
                {
                    string? opAD;
                    do
                    {
                        Console.WriteLine("Menu");
                        Console.WriteLine("1. Cadastro conta corrente");
                        Console.WriteLine("2. Mostrar saldo de todas as contas");
                        Console.WriteLine("3. Excluir conta");
                        Console.WriteLine("4. Voltar ao menu anterior");
                        Console.Write("escolha:");
                        opAD = Console.ReadLine();

                        switch (opAD)
                        {
                            case "1":
                                CadastroContaCorrente();
                                break;
                            case "2":
                                MostrarSaldoContas();
                                break;
                            case "3":
                                ExcluirConta();
                                break;
                            case "4":
                                return;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    } while (opAD != "4");
                }

                public void MenuCaixaEletronico()
                {
                    string? opCE;
                    do
                    {
                        Console.WriteLine("Menu");
                        Console.WriteLine("1. Saque");
                        Console.WriteLine("2. Deposito");
                        Console.WriteLine("3. Transferencia");
                        Console.WriteLine("4. Voltar ao menu anterior");
                        Console.Write("escolha:");
                        opCE = Console.ReadLine();

                        switch (opCE)
                        {
                            case "1":
                                Console.WriteLine("digite o valor a sacar:");
                                string i= Console.ReadLine();
                                double valorS;
                                Double.TryParse.ReadLine(i, out valorS);
                                Sacar(valorS);
                                break;
                            case "2":
                                Console.WriteLine("digite o valor a depositar:");
                                string j = Console.ReadLine();
                                double valorD;
                                Double.TryParse.ReadLine(j, out valorD);
                                Depositar(valorD);
                                break;
                            case "3":
                                ExcluirConta();
                                break;
                            case "4":
                                return;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    } while (opAD != "4");
                }
            } while (op != "3");

            
        }
    }
}