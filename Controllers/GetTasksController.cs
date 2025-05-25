using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class GetTarefasController
    {
        public List<TodoTask> ListarTarefas(string tipoUsuario, string nomeUsuario)
        {
            if (tipoUsuario == "admin")
            {
                return BancoDados.Tarefas;
            }
            else
            {
                return BancoDados.Tarefas.Where(t => t.Usuario == nomeUsuario).ToList();
            }
        }
    }
}
