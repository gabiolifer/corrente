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
        static List<CCorrente> contas=new List<CCorrente>();

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
                        string numeroConta = Console.ReadLine();

                        if (contas.Exists(c => c.numero == numeroConta))
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
            } while (op != "3");
        }

        void MenuAcessoAdministrativo()
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

        void CadastroContaCorrente()
        {
            Console.Write("Digite o número da conta: ");
            string numero = Console.ReadLine();
            Console.Write("Digite o limite da conta: ");
            double limite = Convert.ToDouble(Console.ReadLine());

            CCorrente novaConta = new CCorrente(numero, limite);
            contas.Add(novaConta);
            Console.WriteLine("Conta cadastrada com sucesso.");
        }

        void MostrarSaldoContas()
        {
            Console.WriteLine("----- Saldo de Todas as Contas -----");
            for (int n = 0; n < contas.Count; n++) //pq nn Capacity??
            {
                Console.WriteLine($"Conta: {contas[n + 1].numero} - Saldo: {contas[n + 1].saldo}");
            }
        }

        void ExcluirConta()
        {
            Console.WriteLine("digite o numero da conta a ser excluída: ");
            string numeroConta = Console.ReadLine();

            Console.WriteLine("digite o limite da conta a ser excluída: ");
            double limiteConta = Double.Parse(Console.ReadLine());

            CCorrente conta = contas.Find(c => c.numero == numeroConta && c.limite == limiteConta);

            if (conta!=null)
            {
                conta.status = false;
                Console.WriteLine("Conta excluída com sucesso.");
            }
            else
            {
                Console.WriteLine("a conta não existe");
                return;
            }
            
        }

        void MenuCaixaEletronico()
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
                        Sacar();
                        break;
                    case "2":
                        Depositar();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opCE != "4");
        }

        void Sacar()
        {
            Console.WriteLine("digite o valor do saque:");
            double saque = Double.Parse(Console.ReadLine());

            foreach (double saldo in ??)
            {
                if (saldo <= 0)
                {
                    Console.WriteLine("Não há saldo disponível.");
                    return;
                }
                else if (saque > saldo)
                {
                    int opSaqueSaida;
                    Console.WriteLine($"\nO valor de saque desejado que é maior que o valor do saldo da conta. Deseja retornar ao menu anterior ou sacar todo o valor" +
                        $"presente nesta conta, de R$ {saldo} ? Caso queira voltar, digite 1. Caso contrário, digite 2.\n");
                    Console.WriteLine("Opção escolhida: ");
                    opSaqueSaida = Int32.Parse(Console.ReadLine());
                    if (opSaqueSaida == 1)
                    {
                        Console.WriteLine("Retornando ao menu anterior...\n");
                        return;
                    }
                    else if (opSaqueSaida == 2)
                    {
                        saque == saldo;
                        saldo -= saque;
                        Console.WriteLine($"\nO saque no valor de {saque} desta conta corrente foi realizado com sucesso, tornando seu saldo equivalente a {saldo} reais. ");
                    }
                }
                else
                {
                    saldo -= valorSaque;
                    Console.WriteLine($"\n Saque de {valorSaque} realizado com sucesso. Saldo atual da conta : R$ {saldo}.");
                }
            }
        }

        void Depositar()
        {
            double valord;

            //como o programa sabe q conta q é??
        }

        void Transferir()
        {

        }
    }
}