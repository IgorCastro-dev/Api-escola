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
        public IActionResult salvarEscola([FromBody] Escola escola)
        {
            if (escola == null)
            {
                return BadRequest("A escola não pode ser nula");
            }

            _escolas.Add(escola);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult excluirEscola(int id)
        {
            var alunoParaExcluir = _escolas.FirstOrDefault(e => e.iCodEscola == id);
            if (alunoParaExcluir == null)
            {
                return NotFound();
            }

            _escolas.Remove(alunoParaExcluir);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult atualizarEsola(int id, [FromBody] Escola escolaAtualizado)
        {
            var escolaExistente = _escolas.FirstOrDefault(e => e.iCodEscola == id);
            if (escolaExistente == null)
            {
                return NotFound();
            }

            escolaExistente.sDescricao = escolaAtualizado.sDescricao;

            return Ok();
        }
    }
}
