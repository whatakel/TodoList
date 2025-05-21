// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Http;
// using TodoList.Models;

// namespace TodoList.Routes;

// public static class Controllers
// {
//     public static void MapGetRotas(this WebApplication app)
//     {
//         List<TodoTask> tarefas = new List<TodoTask>
//         {
//             new TodoTask { Id = 1, Titulo = "Estudar C#", Status = false },
//             new TodoTask { Id = 2, Titulo = "Treinar vôlei", Status = true, ConcluidoEm = DateTime.Now }
//         };

//         app.MapGet("/", () => "API de Tarefas em funcionamento!\n --------------PARA ENTRAR DIGITE /entrar na url--------------");

//         app.MapGet("/entrar", () => "Caso você seja um usuario normal use    \n\n  ------ /usuario/tarefas   \n  ou   \n  ------ /usuario/tarefas/(o id da tarefa q vc deseja filtrar)");

//         //dps com o post usar outras rotas para adicionar ou excluir alguma tarefa como admin
    
//         app.MapGet("/entrar/usuario/tarefas", () =>
//         {
//             var tarefasFormatadas = tarefas.Select(t => new {
//                 t.Id,
//                 t.Titulo,
//                 t.Status,
//                 CriadoEm = t.CriadoEm.ToString("dd/MM/yyyy HH:mm"),
//                 ConcluidoEm = t.ConcluidoEm?.ToString("dd/MM/yyyy HH:mm") ?? "Não concluído"
//             });

//             return Results.Ok(tarefasFormatadas);
//         });

//         app.MapGet("/entrar/usuario/tarefas/{id}", (int id) =>
//         {
//             var tarefa = tarefas.FirstOrDefault(t => t.Id == id);

//             if (tarefa == null)
//                 return Results.NotFound("Tarefa não encontrada.");

//             var tarefaFormatada = new
//             {
//                 tarefa.Id,
//                 tarefa.Titulo,
//                 tarefa.Status,
//                 CriadoEm = tarefa.CriadoEm.ToString("dd/MM/yyyy HH:mm"),
//                 ConcluidoEm = tarefa.ConcluidoEm?.ToString("dd/MM/yyyy HH:mm") ?? "Não concluído"
//             };

//             return Results.Ok(tarefaFormatada);

//             //para o proprio usuario falar q terminou uma atividade teria q usar o put q agt n pode usar na ativiade ent todas as att vao ficar com data de inicio e fim da tarefa igual

//         });
//     }
// }
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
