using API_Escola.Models;

public class AlunoService : IAlunoService
{

    private static List<Aluno> _alunos = new List<Aluno>();


    public List<Aluno> listarAlunos()
    {
        return _alunos;
    }

    public Aluno getAlunoById(int id)
    {
        var alunoExistente = _alunos.FirstOrDefault(a => a.iCodAluno == id);
        return alunoExistente;
    }

    public void atualizaAluno(Aluno alunoExistente, AlunoDto alunoAtualizado)
    {
        alunoExistente.dNascimento = alunoAtualizado.dNascimento;
        alunoExistente.sEndereco = alunoAtualizado.sEndereco;
        alunoExistente.sCelular = alunoAtualizado.sCelular;
        alunoExistente.sCPF = alunoAtualizado.sCPF;
        alunoExistente.iCodEscola = alunoAtualizado.iCodEscola;
        alunoExistente.sNome = alunoAtualizado.sNome;

    }

    public void salvaAluno(AlunoDto alunoDto)
    {
        Aluno aluno = new Aluno();
        aluno.iCodAluno = _alunos.Count + 1;
        aluno.sNome = alunoDto.sNome;
        aluno.sCPF = alunoDto.sCPF;
        aluno.sCelular = alunoDto.sCelular;
        aluno.sEndereco = alunoDto.sEndereco;
        aluno.iCodEscola = alunoDto.iCodEscola;
        aluno.dNascimento = alunoDto.dNascimento;

        _alunos.Add(aluno);

    }

    public void excluirAluno(Aluno alunoParaExcluir)
    {
        _alunos.Remove(alunoParaExcluir);
    }

    public List<Aluno> getAlunosPorNomeCpf(string dado_usuario) {
        return _alunos.Where(a => a.sCPF == dado_usuario || a.sNome == dado_usuario).ToList();
    }
}