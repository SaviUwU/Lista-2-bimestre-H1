using Lista01Q01_2B.Models;
using Lista01Q01_2B.Repository;
using System.Runtime.Intrinsics.X86;

namespace Lista01Q01_2B.Services
{
    public class NotaAlunoService : INotaAlunoService
    {
        private List<NotaAluno> listaNotasAlunos = new List<NotaAluno>();

        private readonly IAlunoRepository _alunoRepository; 
        private readonly IDisciplinaRepository _disciplinaRepository; 

        public NotaAlunoService(IAlunoRepository alunoRepository, IDisciplinaRepository disciplinaRepository){
            
            _alunoRepository = alunoRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        public void InserirNota(NotaAluno nota)
        {
            
            var alunoExistente = _alunoRepository.obterAlunosPorRA(nota.RaAluno);
            if (alunoExistente == null)
            {
                throw new InvalidOperationException("Aluno Inexistente");
            }

            
            var disciplinaExistente = _disciplinaRepository.getDisciplinaPorNome(nota.IdDisciplina.ToString()); 
            if (disciplinaExistente == null){
               
                throw new InvalidOperationException("Disciplina Inexistente.");
            }

            
            bool notaExistente = listaNotasAlunos.Any(n => n.RaAluno == nota.RaAluno && n.IdDisciplina == nota.IdDisciplina);
            if (notaExistente){
                
                throw new InvalidOperationException("Nota para aluno nesta disciplina ja registrada.");
            }
            
            listaNotasAlunos.Add(nota);
        }
    }
}
