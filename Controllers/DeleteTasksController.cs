// using TodoList.Models; 

// public static class Rota_DELETE
// {
//     public static void MapDeleteRoutes(this WebApplication app)
//     {
//         app.MapDelete("/tarefas/{id}", async (int id, AppDbContext context) =>
//         {
//             var tarefa = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

//             if (tarefa == null)
//                 return Results.BadRequest("Tarefa não encontrada.");

//             context.Tasks.Remove(tarefa);
//             await context.SaveChangesAsync();

//             return Results.Ok("Tarefa deletada com sucesso.");
//         });
//     }
// }
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
