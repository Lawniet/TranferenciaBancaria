using System;
using System.Collections.Generic;

class Program {
  static List<Conta> listaContas = new List<Conta>();
  public static void Main (string[] args) {
    string opcaoUsuario = ObterOpcaoUsuario();
    while (opcaoUsuario.ToUpper() != "X"){
      switch (opcaoUsuario){
        case "1":
          ListarContas();
          break;
        case "2":
          InserirConta();
          break;
        case "3":
          Transferir();
          break;
        case "4":
          Sacar();
          break;
        case "5":
          Depositar();
          break;
        case "C":
          Console.Clear();
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      opcaoUsuario = ObterOpcaoUsuario();
    }
    Console.WriteLine("Obrigada por utilizar nossos serviços.");
    Console.ReadLine();
  }
  private static void InserirConta(){
    Console.WriteLine("Criando nova conta");

    Console.WriteLine("Digite um número para definir o tipo da Conta, sendo 1 para Física e 2 para Jurídica: ");
    int entradaTipoConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o nome do Cliente: ");
    string entradaNome = Console.ReadLine();

    Console.WriteLine("Digite o saldo inicial: ");
    double entradaSaldo = double.Parse(Console.ReadLine());

    Console.WriteLine("Digite o crédito: ");
    double entradaCredito = double.Parse(Console.ReadLine());

    Conta novaConta = new Conta(tipoConta : (TipoConta)entradaTipoConta, 
                                saldo: entradaSaldo, 
                                credito: entradaCredito, 
                                nome: entradaNome);

    listaContas.Add(novaConta);
  }
  private static void ListarContas(){
    Console.WriteLine("Listar contas");

    if(listaContas.Count == 0){
      Console.WriteLine("Nenhuma conta cadastrada até o momento!");
      return;
    }
    for (int i = 0; i < listaContas.Count; i++){
      Conta conta = listaContas[i];
      Console.WriteLine("#{0} . ", i);
      Console.WriteLine(conta);
    }
  }
  private static void Sacar(){
    Console.WriteLine("Saque em conta");

    Console.WriteLine("Digite o número da conta: ");
    int indiceConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser sacado: ");
    double valorSaque = double.Parse(Console.ReadLine());

    listaContas[indiceConta].Sacar(valorSaque);
  }
  private static void Depositar(){
    Console.WriteLine("Depósito em conta");

    Console.WriteLine("Digite o número da conta: ");
    int indiceConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser depositado: ");
    double valorDeposito = double.Parse(Console.ReadLine());

    listaContas[indiceConta].Depositar(valorDeposito);
  }
  private static void Transferir(){
    Console.WriteLine("Transferência entre contas");

    Console.WriteLine("Digite o número da conta de origem: ");
    int indiceContaOrigem = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o número da conta de destino: ");
    int indiceContaDestino = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser transferido: ");
    double valorTransferencia = double.Parse(Console.ReadLine());

    listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
  }
  private static string ObterOpcaoUsuario(){
    Console.WriteLine();
    Console.WriteLine("Serviços bancários ao seu dispor!");
    Console.WriteLine("Informe a operação desejada, conforme a lista abaixo: ");

    Console.WriteLine("1 - Listar contas");
    Console.WriteLine("2 - Criar nova conta");
    Console.WriteLine("3 - Transferir um valor");
    Console.WriteLine("4 - Sacar um valor");
    Console.WriteLine("5 - Depositar um valor");
    Console.WriteLine("C - Lipar tela");
    Console.WriteLine("X - Sair da aplicação");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
  }
}