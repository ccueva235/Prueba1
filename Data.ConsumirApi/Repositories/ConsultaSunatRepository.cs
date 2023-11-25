using Domain.Models;
using Domain.Models.Properties;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql.Repositories
{
    public class ConsultaSunatRepository : IConsultaSunatRepository
    {
        private readonly ConsultaApiSunat consultaApiSunat;
        private readonly HttpClient _httpClient;

        public ConsultaSunatRepository(
         IOptions<ConsultaApiSunat> consultaApiSunat
         )
        {
            _httpClient = new HttpClient();
            this.consultaApiSunat = consultaApiSunat.Value;
            _httpClient.BaseAddress = new Uri(this.consultaApiSunat.URL);

        }

        public async Task<ConsultaSunat> BuscarDNI(string DNI)
        {
            IConfiguration config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .Build();

            string baseUrl = _httpClient.BaseAddress.AbsoluteUri;
            
            string documentNumber = DNI;

            string apiUrl = baseUrl + documentNumber;

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                request.Headers.Add("Authorization", $"Bearer {this.consultaApiSunat.Token}");

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserializar la respuesta JSON a la clase ApiResponse
                    ConsultaSunat apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsultaSunat>(jsonResponse);

                    return apiResponse;
                }
                else
                {
                    Console.WriteLine($"Error al hacer la solicitud: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null; // O podrías manejar el error de alguna otra manera según tu lógica.
        }

    

    }
}
