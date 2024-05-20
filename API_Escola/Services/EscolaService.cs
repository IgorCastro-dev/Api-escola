using API_Escola.Models;

public class EscolaService : IEscolaService
{
    private static List<Escola> _escolas = new List<Escola>();


    private readonly IAlunoService _alunoService;

    public EscolaService(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    public Escola GetEscolaById(int id) {
        var teste = _escolas.FirstOrDefault(e => e.iCodEscola == id);
        return teste;
    }

    public Escola[] listaEscolas()
    {
        return _escolas.ToArray();
    }

    public void salvaEscola(EscolaDto escolaDto) {

        Escola escola = new Escola();
        escola.iCodEscola = _escolas.Count + 1;
        escola.sDescricao = escolaDto.sDescricao;
        _escolas.Add(escola);

    }

    public void excluirEscola(Escola escolaParaExcluir)
    {
        List<Aluno> alunos = _alunoService.listarAlunos();

        foreach (var aluno in alunos)
        {
            if (aluno.iCodEscola == escolaParaExcluir.iCodEscola)
            {
                _alunoService.excluirAluno(aluno);
            }
        }

        _escolas.Remove(escolaParaExcluir);
    }

    public void atualizaEscola(Escola escolaExistente,EscolaDto escolaAtualizado)
    {
        escolaExistente.sDescricao = escolaAtualizado.sDescricao;
    }

    public List<Escola> buscarPorDescricao(string descricao)
    {
        List<Escola> alunos = _escolas.Where(e => e.sDescricao.Contains(descricao)).ToList();
        return alunos;
    }

}