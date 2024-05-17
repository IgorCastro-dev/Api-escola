using API_Escola.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Escola.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        private static List<Aluno> _alunos = new List<Aluno>();


        [HttpGet("listar",Name = "Salvaaluno")]
        public ActionResult<List<Aluno>> listarAlunos()
        {

            return Ok(_alunos);
        }

        [HttpPost("salvar")]
        public IActionResult SalvarAluno([FromBody] Aluno aluno)
        {
            if (aluno == null)
            {
                return BadRequest("O aluno não pode ser nulo");
            }

            _alunos.Add(aluno);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirAluno(int id)
        {
            var alunoParaExcluir = _alunos.FirstOrDefault(a => a.iCodAluno == id);
            if (alunoParaExcluir == null)
            {
                return NotFound();
            }

            _alunos.Remove(alunoParaExcluir);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarAluno(int id, [FromBody] Aluno alunoAtualizado)
        {
            var alunoExistente = _alunos.FirstOrDefault(a => a.iCodAluno == id);
            if (alunoExistente == null)
            {
                return NotFound();
            }

            alunoExistente.sCelular = alunoAtualizado.sCelular;
            alunoExistente.sCPF= alunoAtualizado.sCPF;
            alunoExistente.iCodEscola = alunoAtualizado.iCodEscola;
            alunoExistente.sNome = alunoAtualizado.sNome;

            return Ok();
        }

        [HttpGet("buscar/{dado_usuario}", Name = "Buscar Por nome e cpf")]
        public ActionResult<Aluno> buscarPorNomeCpf(string dado_usuario)
        {
            var aluno = _alunos.FirstOrDefault(a => a.sCPF == dado_usuario || a.sNome == dado_usuario);
            return Ok(aluno);
        }
    }

}