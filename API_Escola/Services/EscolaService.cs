public class EscolaService : IEscolaService
{
    private static List<Escola> _escolas = new List<Escola>();



    public Escola GetEscolaById(int id) {
        Console.WriteLine("printa aqui:" + id);
        var teste = _escolas.FirstOrDefault(e => e.iCodEscola == id);
        Console.WriteLine("printa aqui:"+ teste);
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

}