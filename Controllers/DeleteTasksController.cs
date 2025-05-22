using System;
using System.Linq;
using TodoList.Data;

namespace TodoList.Controllers
{
    public class DeleteTarefaController
    {
        public bool ApagarTarefa(int id, string tipoUsuario, string nomeUsuario)
        {
            var tarefa = BancoDados.Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
                return false;

            // Admin pode apagar qualquer tarefa
            if (tipoUsuario == "admin" || tarefa.Usuario == nomeUsuario)
            {
                BancoDados.Tarefas.Remove(tarefa);
                BancoDados.SalvarDados();
                return true;
            }

            return false;
        }
    }
}
