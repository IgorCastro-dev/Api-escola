public interface IEscolaService
{
    Escola GetEscolaById(int id);

    Escola[] listaEscolas();

    void salvaEscola(EscolaDto escolaDto);

    void excluirEscola(Escola escolaParaExcluir);

    void atualizaEscola(Escola escolaExistente, EscolaDto escolaAtualizado);

    List<Escola> buscarPorDescricao(string descricao);
}
