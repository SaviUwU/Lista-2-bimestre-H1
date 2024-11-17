﻿using Lista01Q01_2B.Models;
using Lista01Q01_2B.Repository;

namespace Lista01Q01_2B.Services
{
    public class DisciplinaService : IDisciplinaService
    {

        private readonly IDisciplinaRepository _repository;

        public DisciplinaService(IDisciplinaRepository repository)
        {
            _repository = repository;   
        }

        public List<Disciplina> getDisciplina()
        {
            return _repository.getDisciplina();
        }

        public bool inserirDisciplina(Disciplina disciplina)
        {
            if (_repository.getDisciplinaPorNome(disciplina.Nome) == null) 
            {
                _repository.inserirDisciplina(disciplina);
                return true; 
            }
            return false; 
        }
    }
}
