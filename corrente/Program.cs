using corrente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

List<CCorrente>? contas=new List<CCorrente>();
 
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
            CCorrente? conta = contas.Find(c => c.numero == numeroConta);

            if (conta!=null)
            {
                MenuCaixaEletronico(conta); break;
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
            string? numero = Console.ReadLine();
            Console.Write("Digite o limite da conta: ");
            double limite = Convert.ToDouble(Console.ReadLine());

            CCorrente? novaConta = new CCorrente(numero, limite);
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
            string? numeroConta = Console.ReadLine();

            Console.WriteLine("digite o limite da conta a ser excluída: ");
            double? limiteConta = Double.Parse(Console.ReadLine());

            CCorrente? conta = contas.Find(c => c.numero == numeroConta && c.limite == limiteConta);

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

void MenuCaixaEletronico(CCorrente conta)
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
                        Sacar(conta);
                        break;
                    case "2":
                        Depositar(conta);
                        break;
                    case "3":
                        Transferir(conta);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opCE != "4");
}

void Sacar(CCorrente conta)
{
    Console.WriteLine("digite o valor do saque:");
    double saque = Double.Parse(Console.ReadLine());
    if(conta.Sacar(saque))
    {
        Console.WriteLine("Saque efetuado com sucesso");
    }
    else
    {
        Console.WriteLine("Nao foi possivel realizar o saque.");
    }
}

void Depositar(CCorrente conta)
{
    double? valord;
    Console.WriteLine("digite o valor a ser depositado:");
    double dep = Double.Parse(Console.ReadLine());

    if (conta.Depositar(dep))
    {
        Console.WriteLine("O deposito foi efetuado com sucesso");
    }
    else
    {
        Console.WriteLine("Nao foi possivel realizar o deposito.");
    }
}

 void Transferir(CCorrente conta)
{
    Console.WriteLine("para qual conta deseja transferir(digite o numero)?");
    string? numdep = Console.ReadLine();
    CCorrente? contatf = contas.Find(c => c.numero == numdep);

    Console.WriteLine("qual o valor da transferencia?");
    double valordep = Double.Parse(Console.ReadLine());

    conta.Transferir(contatf, valordep);

    if (conta.Transferir(contatf, valordep))
    {
        Console.WriteLine("a transferencia foi efetuada com sucesso");
    }
    else
    {
        Console.WriteLine("Nao foi possivel realizar a transferencia.");
    }
}