using API_Escola.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Escola.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IEscolaService _escolaService;

        public AlunoController(IEscolaService escolaService, IAlunoService alunoService)
        {
            _escolaService = escolaService;
            _alunoService = alunoService;
        }


        [HttpGet("listar",Name = "Salvaaluno")]
        public ActionResult<List<Aluno>> listarAlunos()
        {

            return Ok(_alunoService.listarAlunos());
        }

        [HttpPost("salvar")]
        public IActionResult SalvarAluno([FromBody] AlunoDto alunoDto)
        {

            if (alunoDto == null)
            {
                return BadRequest("O aluno não pode ser nulo");
            }
            if(_escolaService.GetEscolaById(alunoDto.iCodEscola) == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }

            _alunoService.salvaAluno(alunoDto);

            
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirAluno(int id)
        {
            var alunoParaExcluir = _alunoService.getAlunoById(id);
            if (alunoParaExcluir == null)
            {
                return BadRequest("Aluno não vínculado com esse ID");
            }

            _alunoService.excluirAluno(alunoParaExcluir);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarAluno(int id, [FromBody] AlunoDto alunoAtualizado)
        {
            var alunoExistente = _alunoService.getAlunoById(id);
            if (alunoExistente == null)
            {
                return BadRequest("Aluno não vínculado com esse ID");
            }

            if(_escolaService.GetEscolaById(alunoAtualizado.iCodEscola) == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }
            _alunoService.atualizaAluno(alunoExistente,alunoAtualizado);

            return Ok();
        }

        [HttpGet("buscar/{dado_usuario}", Name = "Buscar Por nome e cpf")]
        public ActionResult<Aluno[]> buscarPorNomeCpf(string dado_usuario)
        {
            
            return Ok(_alunoService.getAlunosPorNomeCpf(dado_usuario));
        }

        [HttpGet("buscarById/{id}", Name = "Buscar Por Id")]
        public ActionResult<Aluno> buscarPorId(int id)
        {

            var alunoExistente = _alunoService.getAlunoById(id);

            if (alunoExistente == null)
            {
                return BadRequest("Aluno não vínculado com esse ID");
            }
            return Ok(alunoExistente);
        }


    }
}