using Estrutura_back_end_API.Models;
using Estrutura_back_end_API.Models.Cursos;
using Estrutura_back_end_API.Models.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Estrutura_back_end_API.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite cadastrar curso para o usuario autenticado 
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuario</returns>"
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao cadastrar um curso", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Não autorizado", Type = typeof(ValidaCampoViewModelOutput))]
       
        [HttpPost]
        [Route(" ")]

        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuario 
        /// </summary>
        /// <returns>Retorna status ok e dados do curso do usuario</returns>"
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter curso", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Não autorizado", Type = typeof(ValidaCampoViewModelOutput))]

        [HttpGet]
        [Route(" ")]

        public async Task<IActionResult> Get(CursoViewModelInput cursoViewModelInput)
        {
            var cursos = new List<CursoViewModelOutput>();
            cursos.Add(new CursoViewModelOutput()
            {
                Login = codigoUsuario.ToString(),
                Descricao = "teste",
                Nome = "teste"
            });
            return Ok(cursos);
        }
    }
}
