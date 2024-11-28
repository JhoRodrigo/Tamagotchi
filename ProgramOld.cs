using Newtonsoft.Json;
using RestSharp;
using System;
using Tamagotchi;

public class ProgramOld
{
    public static void Main(string[] args)
    {
        ////////////////////////////////////////////////////////////////////////
        ///INICIO 1 DIA
        // Criar o código C# que execultará um requisição HTTP do tipo Get
        // Execultar a requisição e pegar a resposta (o Json)
        // Imprimir o Resultado no Console
        ////////////////////////////////////////////////////////////////////////
        //Obter a lista de especies de Pokémons
        var client = new RestSharp.RestClient("https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest(Method.GET);
        IRestResponse response = client.Execute(request);

        var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

        //Apresentar as opções ao Jogador
        Console.WriteLine("Escolha um Tamagotchi: ");
        for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemonEspeciesResposta.Results[i].Name}");
        }

        //Obter a escolha do jogador
        int escolha;

        while (true)
        {
            Console.WriteLine("\n");
            Console.Write("Escolha um número: ");
            if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
            {
                Console.WriteLine("Escolha inválida. Tente novamente");
            }
            else
                break;
        }

        //Obter as caracteristicas do Pokemon escolhido
        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
        request = new RestRequest(Method.GET);
        response = client.Execute(request);
        // Mostrar as características ao jogador
        //Console.WriteLine(response.Content);
        ///FIM 1 DIA
        ///////////////////////////////////////////////////////////////////////////////////////////////
        ///INICIO 2 DIA
        // Filtro do JSON os Campos:
        // - Ability
        // - Heigth
        // - Weight
        //////////////////////////////////////////////////////////////////////////////////////////////
        var pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);
        var pokemonEscolhido = pokemonEspeciesResposta.Results[escolha - 1];

        //Mostrar as caracteristicas ao jogador
        Console.WriteLine("\n");
        Console.WriteLine($"Você escolheu {pokemonEscolhido.Name}!");
        Console.WriteLine($"Detalhes: ");
        Console.WriteLine($"- Nome: {pokemonEscolhido.Name}");
        Console.WriteLine($"- Peso: {pokemonDetalhes.Weight}");
        Console.WriteLine($"- Altura: {pokemonDetalhes.Height}");

        Console.WriteLine("\n Habilidades do Mascote: ");

        foreach (var abilityDetail in pokemonDetalhes.Abilities)
        {
            Console.WriteLine("Nome da Habilidade: " + abilityDetail.Ability.Name);
        }

        Console.WriteLine("\n");
        ///FIM 2 DIA
        ///////////////////////////////////////////////////////////////////////////////////////////////
        ///INICIO 3 DIA
        ///Criar uma classe que deve conter:
        ///* Dar boas vindas ao usuario, ler o nome da pessoa e dados que voce achar relevante
        ///* Exibir um menu que possibilite: "Adoção de mascotes", "Ver mascotes adotados" e "Sair do Jogo"
        ///

    }
}