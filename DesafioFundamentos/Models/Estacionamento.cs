namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            
            while (true)
            {
                Console.Write("Digite uma placa valída do veículo para estacionar: ");
                string placa = Console.ReadLine();
                
                if (placa.Length != 7)
                // Verifica se a placa tem 7 caracteres
                {
                    Console.WriteLine("Placa inválida");
                    continue;
                }
                else // Verifica se a placa tem 3 letras, 1 número, 1 letra e 2 números
                {
                    string verificacao = placa.Substring(0 , 3);
                    
                    if (verificacao.All(char.IsLetter))
                    // Se tiver 3 letras no começo
                    {
                        string verificacao2 = placa[3].ToString();
                        
                        if (verificacao2.All(char.IsDigit))
                        // Se tiver 1 número depois das 3 letras
                        {
                            string verificacao3 = placa[4].ToString();
                            
                            if (verificacao3.All(char.IsLetter))
                            // Se tiver 1 letra depois do número
                            {
                                string verificacao4 = placa.Substring(5 , 2);

                                if (verificacao4.All(char.IsDigit))
                                // Se tiver 2 números depois da letra
                                {
                                    veiculos.Add(placa);
                                    break;
                                }
                                else
                                { // Se não tiver 2 números depois da letra
                                    Console.WriteLine("Placa inválida");
                                    continue;
                                }
                            }
                            else
                            { // Se não tiver 1 letra depois do número
                                Console.WriteLine("Placa inválida");
                                continue;
                            }
                        }
                        else
                        { // Se não tiver 1 número depois das 3 letras
                            Console.WriteLine("Placa inválida");
                            continue;
                        }
                    }
                    else
                    { // Se não tiver 3 letras no começo
                        Console.WriteLine("Placa inválida");
                        continue;
                    }    
                }
            }
                
                

            }

        public void RemoverVeiculo()
        {
            if (veiculos.Any()) // Se houver veículos
            {
                Console.Write("Digite a placa do veículo para remover: ");

                // Pedir para o usuário digitar a placa e armazenar na variável placa
                // *IMPLEMENTE AQUI*
                string placa = Console.ReadLine();

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {  // Se existir, pedir para o usuário digitar o horário de saída
                    while (true)
                    {   try
                        {  // Pedir para o usuário digitar o horário de saída
                            Console.Write("Digite a quantidade de HORAS que o veículo permaneceu estacionado: ");
                            int horas = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite a quantidade de MINUTOS que o veículo permaneceu estacionado: ");
                            int minutos = Convert.ToInt32(Console.ReadLine());
                            
                            // Calcula o valor total a ser pago
                            decimal valorTotal = precoInicial + (horas * precoPorHora) + (minutos * (precoPorHora / 60));
                            
                            veiculos.Remove(placa); // Remove o veículo da lista
                            Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal.ToString("R$0.00")}");
                            break;
                        }
                        catch (FormatException) // Se o usuário digitar um horário inválido
                        {
                            Console.WriteLine("Por favor, digite um horário válido.");
                        }

                    }    
                }
                else // Se não existir
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else // Se não houver veículos
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()) // Se houver veículos
            {
                Console.WriteLine("Os veículos estacionados são:");
                Console.WriteLine(); // Pula uma linha
                
                // Percorrer a lista de veículos e exibir no console
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine(veiculos[i].ToUpper());
                }
                Console.WriteLine(); // Pula uma linha
            }
            else // Se não houver veículos
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
