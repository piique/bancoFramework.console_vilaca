using Application;
using CpfCnpjLibrary;
using Domain.Model;
using Repository;

namespace bancoFramework;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = await Identificacao();
        
        Menu(cliente);
    }
        
    private static async Task<Cliente> Identificacao()
    {
        var listaErros = new List<string>();
        var cliente = new Cliente();

        do
        {
            listaErros.Clear();
            
            Console.Write("Seu número de identificação: ");
            var id = Console.ReadLine() ?? "";
            if (!int.TryParse(id, out var idInt))
            {
                listaErros.Add("Identificador não é válido");    
            }
            else
            {
                var returnedClient = await ClientRepository.GetCliente(idInt);
                if (returnedClient != null) return returnedClient;
                cliente.Id = idInt;
            }
            
            Console.Write("Seu nome: ");
            cliente.Nome = Console.ReadLine() ?? "";
        
            Console.Write("Seu CPF: ");
            cliente.Cpf = Console.ReadLine() ?? "";
            if(!Cpf.Validar(cliente.Cpf))
                listaErros.Add("CPF digitado não é válido");
            else
                cliente.Cpf = Cpf.FormatarSemPontuacao(cliente.Cpf);
        
            Console.Write("Seu saldo: ");
            var saldo = Console.ReadLine() ?? "";
            if (!float.TryParse(saldo, out var saldoFloat))
                listaErros.Add("Saldo digitado não é válido");
            else
                cliente.Saldo = saldoFloat;

            if (listaErros.Count == 0) continue;
            Console.Clear();
            Console.WriteLine("Erro(s) encontrado(s):");
            foreach (var erro in listaErros)
            {
                Console.WriteLine($"  * {erro}");
            }
            Console.WriteLine("Precione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Preencha os dados nonvamente!");


        } while (listaErros.Count > 0);

        Console.Clear();
        
        await ClientRepository.AddCliente(cliente);
        
        return cliente;
    }

    private static void Menu(Cliente cliente)
    {
        string? opcao;
        do
        {
            Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Exibir saldo");
            Console.WriteLine("4 - Sair");
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
                    Console.WriteLine("Saldo");
                    Console.WriteLine("Seu saldo é: " + cliente.Saldo);
                    Console.WriteLine("Precione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        } while (opcao != "4");
    }
}