using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");

while (true) // Loop para obter o preço inicial valído
{
    try
    {
        Console.Write("\nDigite o preço inicial: ");
        precoInicial = Convert.ToDecimal(Console.ReadLine());
        break;  
    }
    catch (FormatException)
    { // Se o preço não for um número
        Console.WriteLine("Por favor, digite um preço válido.");
    }
}


while (true)
{ // Loop para obter o preço por hora valído
    try
    {
        Console.Write("\nAgora digite o preço por hora: ");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());
        break;  
    }
    catch (FormatException)
    { // Se o preço não for um número
        Console.WriteLine("Por favor, digite um preço válido.");
    }
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento parkingLot = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            parkingLot.AdicionarVeiculo();
            break;

        case "2":
            parkingLot.RemoverVeiculo();
            break;

        case "3":
            parkingLot.ListarVeiculos();
            break;

        case "4":
            Console.WriteLine("Obrigado por utilizar os nossos serviços!");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.Write("Pressione uma tecla para continuar: ");
    Console.ReadLine();
}