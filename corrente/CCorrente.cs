using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace corrente
{
    public class CCorrente
    {
        public string numero;
        public double saldo;
        public double limite;
        public bool status;
        public bool especial;
        public List<Transação> lista;

        public bool Sacar(double valor)
        {
            if (saldo - valor > -limite)
            {
                saldo -= valor;
                lista.Add(new Transação(valor, 'S'));
                return true;
            }
            return false;

            
        }

        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                lista.Add(new Transação(valor, 'D'));
                return true;
            }
            return false;

        }

        public bool Transferir(CCorrente destino, double valor)
        {
            if(destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                lista[lista.Count - 1].duplicata = destino.lista[destino.lista.Count - 1];
                destino.lista[destino.lista.Count - 1].duplicata = lista[lista.Count - 1];
                return true;
            }
            return false;
        }

        public CCorrente(string numero, double limite):this()
        {
            this.numero = numero; //atributo numero igual a parametro numero
            this.limite = limite;
        }

        public CCorrente()
        {
            this.saldo = 0;
            this.status = true;
            lista = new List<Transação>();
        }
    }
}
