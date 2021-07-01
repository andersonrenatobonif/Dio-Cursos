using CatalogoJogos.Exceptions;
using CatalogoJogos.InputModel;
using CatalogoJogos.Services;
using CatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Controllers.V1
{
    [Route("api/V1[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("(IdJogo:guid)")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute]Guid IdJogo)
        {
            var jogo = await _jogoService.Obter(IdJogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }


        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastradoException)
            
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
           
        }

        [HttpPut("(IdJogo:guid)")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid IdJogo,[FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(IdJogo, jogoInputModel);

                return Ok();
            }
            catch(JogoNaoCadastradoException)
            
            {
                return NotFound("Não existe este jogo");
            }
            
        }


        [HttpPatch("(IdJogo:guid)/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid IdJogo,[FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(IdJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpDelete("(IdJogo:guid)")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid IdJogo)
        {
            try
            {
                await _jogoService.Remover(IdJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException)
            
            {
                return NotFound("Não existe este jogo");
            }
        }



    }
}
