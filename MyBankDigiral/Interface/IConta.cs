using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankDigiral.Interface
{
    public interface IConta
    {
        void Depositar(double valor);
        bool Sacar(double valor);
        double ConsultaSaldo();
        string GetCodigoBanco();
        string GetNumeroAgencia();
        string GetNumeroConta();
        string GetNomeBanco();  

    }
}
