using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlunosController : ControllerBase
    {
        private IAlunosService _alunosService;
        public AlunosController(IAlunosService alunosService)
        {
            _alunosService = alunosService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunosService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {                
                //return BadRequest("");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByNome([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunosService.GetAlunosByNome(nome);

                if(alunos==null) return NotFound($"Não existem alunos com o critério {nome}");
                
                return Ok(alunos);
            }
            catch
            {                
                return BadRequest("Request Inválido");
            }
        }

        [HttpGet("{id:int}", Name="GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunosService.GetAluno(id);
                if(aluno==null) return NotFound($"Não existe aluno com id = {id}");
                
                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunosService.CreateAluno(aluno);               
                
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if(aluno.Id == id)
                {
                    await _alunosService.UpdateAluno(aluno);
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                }        
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunosService.GetAluno(id);
                if(aluno != null)
                {
                    await _alunosService.DeleteAluno(aluno);
                    return Ok($"Aluno de id={id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Aluno com id={id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }
    }
}