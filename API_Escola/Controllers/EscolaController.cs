using API_Escola.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Escola.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscolaController : ControllerBase
    {
        private static List<Escola> _escolas = new List<Escola>();

        [HttpGet("listar", Name = "SalvaEscola")]
        public ActionResult<List<Escola>> listarEscola()
        {

            return Ok(_escolas);
        }

        [HttpPost("salvar")]
        public IActionResult salvarEscola([FromBody] EscolaDto escolaDto)
        {
            if (escolaDto == null)
            {
                return BadRequest("A escola não pode ser nula");
            }

            Escola escola = new Escola();
            escola.iCodEscola = _escolas.Count + 1;
            escola.sDescricao = escolaDto.sDescricao;

            _escolas.Add(escola);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult excluirEscola(int id)
        {
            var escolaParaExcluir = getEscolaById(id);
            if (escolaParaExcluir == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }

            _escolas.Remove(escolaParaExcluir);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult atualizarEsola(int id, [FromBody] Escola escolaAtualizado)
        {
            var escolaExistente = getEscolaById(id);
            if (escolaExistente == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }

            escolaExistente.sDescricao = escolaAtualizado.sDescricao;

            return Ok();
        }

        [HttpGet("buscarById/{id}", Name = "Buscar Escola Por Id")]
        public ActionResult<Escola> buscarPorId(int id)
        {
            var escolaExistente = getEscolaById(id);
            if(escolaExistente == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }
            return Ok(escolaExistente);
        }

        [HttpGet("buscar/{descricao}", Name = "Buscar Por Descricao")]
        public ActionResult<Escola[]> buscarPorDescricao(string descricao)
        {
            List<Escola> alunos = _escolas.Where(e => e.sDescricao == descricao).ToList();
            return Ok(alunos);
        }

        public static Escola getEscolaById(int id)
        {
            var escolaExistente = _escolas.FirstOrDefault(e => e.iCodEscola == id);
            return escolaExistente;
        }
    }
}
