﻿using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirNovaConta();
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

            Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Transferindo recursos");
            Console.WriteLine();

            Console.Write("Digite a conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite a conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }

        private static void Depositar()
        {
            Console.WriteLine("Realizando depósito bancário");
            Console.WriteLine();

            Console.Write("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que deseja depositar");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listando Contas");
            Console.WriteLine();

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i ++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirNovaConta()
        {
            Console.WriteLine("Inserindo nova conta");
            Console.WriteLine();

            Console.Write("Digite 1 para pessoa física ou 2 para pessoa jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo, 
                                                    credito: entradaCredito,
                                                    nome: entradaNome);

            listContas.Add(novaConta);
        }

          private static void Sacar()
        {
            Console.WriteLine("Sacando dinheiro");
            Console.WriteLine();

            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a sey dispor!");
            Console.WriteLine("Informe a opção desejada: ");
            
            Console.WriteLine("1- Listar contas: ");
            Console.WriteLine("2- Inserir nova conta: ");
            Console.WriteLine("3- Transferir: ");
            Console.WriteLine("4- Sacar: ");
            Console.WriteLine("5- Depositar: ");
            Console.WriteLine("C- Limpar tela: ");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}