using TodoList.Models; 

public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        app.MapDelete("/tarefas/{id}", async (int id, AppDbContext context) =>
        {
            var tarefa = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (tarefa == null)
                return Results.BadRequest("Tarefa não encontrada.");

            context.Tasks.Remove(tarefa);
            await context.SaveChangesAsync();

            return Results.Ok("Tarefa deletada com sucesso.");
        });
    }
}
