using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();
        Menu(pessoa);
    }

    static Pessoa Identificacao()
    {
        var pessoa = new Pessoa();

        Console.Write("Seu número de identificação: ");
        pessoa.Id = int.Parse(s: Console.ReadLine() ?? "");

        Console.Write("Seu nome: ");
        pessoa.Nome = Console.ReadLine() ?? "";

        Console.Write("Seu CPF: ");
        pessoa.Cpf = Console.ReadLine() ?? "";
        Console.Clear();

        return pessoa;
    }

    static void Menu(Pessoa pessoa)
    {
        string? opcao;
        do
        {
            Console.WriteLine($"Como posso ajudar {pessoa.Nome}?");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Sair");
            Console.Write("Opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Depósito");
                    break;
                case "2":
                    Console.WriteLine("Saque");
                    break;
                case "3":
                    break;
                default:
                    Console.Clear();
                    break;
            }
        } while (opcao != "3");
    }
}