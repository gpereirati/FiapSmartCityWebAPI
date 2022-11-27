using FiapSmartCityWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Text;

namespace FiapSmartCityClient
{
    class Program
    {
        static void Main(string[] args)
        {
            get();

            getdesserializado();

            post();

            postserializado();

            Console.Read();
        }

        static void get()
        {
            // Criando um objeto Cliente para conectar com o recurso.
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            // Execute o método Get passando a url da API e salvando o resultado.
            // em um objeto do tipo HttpResponseMessage
            System.Net.Http.HttpResponseMessage resposta =
                client.GetAsync("https://localhost:7013/FiapSmartCityWebAPI/GetSmartCity").Result;

            // Verifica se o Status Code é 200.
            if (resposta.IsSuccessStatusCode)
            {
                // Recupera o conteúdo JSON retornado pela API
                string conteudo = resposta.Content.ReadAsStringAsync().Result;

                // Imprime o conteúdo na janela Console.
                Console.Write(conteudo.ToString());
            }

        }

        static void post()
        {
            // Criando um objeto Cliente para conectar com o recurso.
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            // Conteúdo do tipo de produto em JSON.
            String json = "{\r\n  \"idTipo\": 100,\r\n  \"descricaoTipo\": \"Robo de Limpeza\",\r\n  \"comercializado\": true,\r\n  \"produtos\": [\r\n    {\r\n      \"idProduto\": 0,\r\n      \"nomeProduto\": \"string\",\r\n      \"caracteristicas\": \"string\",\r\n      \"precoMedio\": 0,\r\n      \"logotipo\": \"string\",\r\n      \"ativo\": true\r\n    }\r\n  ]\r\n}";
            // Convertendo texto para JSON StringContent. 
            StringContent conteudo = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            // Execute o método POST passando a url da API 
            // e envia o conteúdo do tipo StringContent.
            System.Net.Http.HttpResponseMessage resposta =
                client.PostAsync("https://localhost:7013/FiapSmartCityWebAPI", conteudo).Result;

            // Verifica que o POST foi executado com sucesso
            if (resposta.IsSuccessStatusCode)
            {
                Console.WriteLine("Tipo do produto criado com sucesso");
                Console.Write("Link para consulta: " + resposta.Headers.Location);

            }
        }

        static void getdesserializado()
        {
            // Criando um objeto Cliente para conectar com o recurso
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            // Execute o método Get passando a url da API e salvando o resultado 
            // em um objeto do tipo HttpResponseMessage
            System.Net.Http.HttpResponseMessage resposta =
            client.GetAsync("https://localhost:7013/FiapSmartCityWebAPI/GetSmartCity").Result;

            // Verifica se o Status Code é 200
            if (resposta.IsSuccessStatusCode)
            {
                // Recupera o conteúdo JSON retornado pela API
                string conteudo = resposta.Content.ReadAsStringAsync().Result;

                // Convertendo o conteúdo em uma lista de TipoProduto
                List<TipoProduto> lista =
                    JsonConvert.DeserializeObject<List<TipoProduto>>(conteudo);

                // Imprime o conteúdo na janela Console
                foreach (var item in lista)
                {
                    Console.WriteLine("Descrição:" + item.DescricaoTipo);
                    Console.WriteLine("Comercializado:" + item.Comercializado);
                    Console.WriteLine(" ========== ");
                    Console.WriteLine("");
                }

            }

        }

        static void postserializado()
        {
            // Criando um objeto Cliente para conectar com o recurso
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            // Conteudo do tipo de produto em JSON
            TipoProduto tipo = new TipoProduto();
            tipo.IdTipo = 101;
            tipo.DescricaoTipo = "Grid de Energia Solar";
            tipo.Comercializado = true;

            var json = JsonConvert.SerializeObject(tipo);

            // Convertendo texto para JSON StringContent 
            StringContent conteudo = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            // Execute o método POST passando a url da API 
            // e envia o conteudo do tipo StringContent
            System.Net.Http.HttpResponseMessage resposta =
                client.PostAsync("https://localhost:7013/FiapSmartCityWebAPI", conteudo).Result;

            // Verifica que o POST foi executado com sucesso
            if (resposta.IsSuccessStatusCode)
            {
                Console.WriteLine("Tipo do produto criado com sucesso");
                Console.Write("Link para consulta: " + resposta.Headers.Location);
            }
        }
    }
}