public class EscolaService : IEscolaService
{
    private static List<Escola> _escolas = new List<Escola>();



    public Escola GetEscolaById(int id)
    {
        return _escolas.FirstOrDefault(e => e.iCodEscola == id);
    }

    public Escola[] listaEscolas()
    {
        return _escolas.ToArray();
    }

    public void salvaEscola(EscolaDto escolaDto) {

        Escola escola = new Escola();
        escola.iCodEscola = _escolas.Count + 1;
        escola.sDescricao = escolaDto.sDescricao;

        Console.WriteLine(escola); 

        _escolas.Add(escola);

    }

    public void excluirEscola(Escola escolaParaExcluir)
    {
        _escolas.Remove(escolaParaExcluir);
    }

    public void atualizaEscola(Escola escolaExistente,EscolaDto escolaAtualizado)
    {
        escolaExistente.sDescricao = escolaAtualizado.sDescricao;
    }

    public List<Escola> buscarPorDescricao(string descricao)
    {
        List<Escola> alunos = _escolas.Where(e => e.sDescricao == descricao).ToList();
        return alunos;
    }

    public Escola getEscolaById(int id)
    {
        var escolaExistente = _escolas.FirstOrDefault(e => e.iCodEscola == id);

        return escolaExistente;
    }
}