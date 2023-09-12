﻿using Application;
using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao();
        Menu(cliente);
    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();

        Console.Write("Seu número de identificação: ");
        cliente.Id = int.Parse(s: Console.ReadLine() ?? "");

        Console.Write("Seu nome: ");
        cliente.Nome = Console.ReadLine() ?? "";

        Console.Write("Seu CPF: ");
        cliente.Cpf = Console.ReadLine() ?? "";
        Console.Write("Seu saldo: ");

        cliente.Saldo = float.Parse(Console.ReadLine() ?? "0");
        Console.Clear();

        return cliente;
    }

    static void Menu(Cliente cliente)
    {
        string? opcao;
        do
        {
            Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Sair");
            Console.Write("Opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Depósito");
                    Console.Write("Digite o valor: ");
                    cliente.Saldo = Calculo.Soma(cliente.Saldo, float.Parse(Console.ReadLine() ?? "0"));
                    Console.WriteLine("Saldo atual é: " + cliente.Saldo);
                    Console.WriteLine("Precione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Saque");
                    Console.Write("Digite o valor: ");
                    cliente.Saldo = Calculo.Subtracao(cliente.Saldo, float.Parse(Console.ReadLine() ?? "0"));
                    Console.WriteLine("Saldo atual é: " + cliente.Saldo);
                    Console.WriteLine("Precione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        } while (opcao != "3");
    }
}