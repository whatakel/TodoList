using System;
using System.Linq;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class UpdateTaskController
    {
        public bool AtualizarStatus(int id, string tipoUsuario, string nomeUsuario)
        {
            var tarefa = BancoDados.Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
                return false;

            // Admin pode atualizar qualquer tarefa, usuário só pode atualizar suas próprias tarefas
            if (tipoUsuario == "admin" || tarefa.Usuario == nomeUsuario)
            {
                tarefa.Status = !tarefa.Status;
                tarefa.ConcluidoEm = tarefa.Status ? DateTime.Now : null;
                BancoDados.SalvarDados();
                return true;
            }

            return false;
        }
    }
} 