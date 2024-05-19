using API_Escola.Models;

public interface IAlunoService
{
    Aluno getAlunoById(int id);


    List<Aluno> listarAlunos();

    void atualizaAluno(Aluno alunoExistente, AlunoDto alunoNovo);

    void salvaAluno(AlunoDto alunoNovo);

    void excluirAluno(Aluno alunoParaExcluir);

    List<Aluno> getAlunosPorNomeCpf(string dado_usuario);
}