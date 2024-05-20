using Microsoft.AspNetCore.Mvc;

namespace API_Escola.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscolaController : ControllerBase
    {

        private readonly IEscolaService _escolaService;

        public EscolaController(IEscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        [HttpGet("listar", Name = "ListarEscola")]
        public ActionResult<List<Escola>> listarEscola(IEscolaService escolaService)
        {

            return Ok(_escolaService.listaEscolas());
        }

        [HttpPost("salvar")]
        public IActionResult salvarEscola([FromBody] EscolaDto escolaDto)
        {
            if (escolaDto == null)
            {
                return BadRequest("A escola não pode ser nula");
            }

            _escolaService.salvaEscola(escolaDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult excluirEscola(int id)
        {
            var escolaParaExcluir = _escolaService.GetEscolaById(id);
            if (escolaParaExcluir == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }

            _escolaService.excluirEscola(escolaParaExcluir);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult atualizarEscola(int id, [FromBody] EscolaDto escolaAtualizado)
        {
            var escolaExistente = _escolaService.GetEscolaById(id);
            if (escolaExistente == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }

            _escolaService.atualizaEscola(escolaExistente, escolaAtualizado);

            return Ok();
        }

        [HttpGet("buscarById/{id}", Name = "Buscar Escola Por Id")]
        public ActionResult<Escola> buscarPorId(int id)
        {
            var escolaExistente = _escolaService.GetEscolaById(id);
            if (escolaExistente == null)
            {
                return BadRequest("Não existe Escola vínculada com esse ID");
            }
            return Ok(escolaExistente);
        }

        [HttpGet("buscar/{descricao}", Name = "Buscar Por Descricao")]
        public ActionResult<Escola[]> buscarPorDescricao(string descricao)
        {
            return Ok(_escolaService.buscarPorDescricao(descricao));
        }


    }
}
