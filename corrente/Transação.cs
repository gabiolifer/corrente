using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace corrente
{
    public class Transação
    {
        public double valor;
        public char tipo;
        public Transação duplicata;

        public Transação(double valor, char tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
        }
    }
}
