using System;

namespace DIO.Bank
{
    public class Conta
    {
        //CRIAÇÃO DAS PROPRIEDADES OU ATRIBUTOS DA CLASSE, DE MODO PRIVATE PARA NAO SER FACILMENTE ACESSADA SEM HAVER UM MÉTODO PARA ALTERA-LAS
        private TipoConta TipoConta{ get; set; }
        private double Saldo{ get; set; }
        private double Credito{ get; set; }
        private string Nome{ get; set; }

        //CRIACÃO DO CONSULTOR DA CLASSE
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        //METODO SACAR
        public bool Sacar(double valorSaque){

            //Valindação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        //METODO DEPOSITAR
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta {0} é {1} ", this.Nome, this.Saldo);
        }

        //METODO TRANSFERIR
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        //METODO ToString PARA REPRESENTAR ESSA INSTANCIA
        public override string ToString()
            {
                string retorno = "";
                retorno += "TipoConta " + this.TipoConta + " | ";
                retorno += "Nome " + this.Nome + " | ";
                retorno += "Saldo " + this.Saldo + " | ";
                retorno += "Crédito " + this.Credito;
                return retorno;
            }
    }
}