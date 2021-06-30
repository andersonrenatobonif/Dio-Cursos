using Estrutura_back_end_API;
using Estrutura_back_end_API.Models.Usuarios;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace curso.api.tests.Integrations
{
    public class UsuarioControllerTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _httpClient;
        public UsuarioControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            HttpClient httpClient = _factory.CreateClient();
        }

        //WhenGivenThen
        //Quando_Dado_EntaoResultadoEsperado
        [Fact]
        public void Logar()
        {
            //Arrange
            var loginViewModelInput = new LoginViewModelInput
            {
                Login = "andersonsantos",
                Senha = "123445"
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput));

            //Act
            var httpClientRequest = _httpClient.PostAsync("api/v1/usuario/logar", content).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, httpClientRequest.StatusCode);
        }
    }
}
