# TodoList (Delete Task)

### Estrutura do código

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

### Função

O método DELETE em uma API serve para apagar algo do sistema. No caso de uma lista de tarefas, ele exclui uma tarefa específica do banco de dados. Quando o cliente envia uma requisição DELETE, ele informa o ID da tarefa que quer apagar. Por exemplo: `DELETE /api/tasks/3`. A API procura essa tarefa. Se não achar, responde que ela não existe. Se encontrar, remove do banco e confirma que deu certo. Esse método faz parte do básico de uma API RESTful, junto com GET, POST e PUT. Ele garante que dados possam ser excluídos com clareza e segurança.

### Método DELETE

1. **Importação do namespace**

        using TodoList.Models;
   

Importa a definição das entidades, como a classe da tarefa, para usar no código.

2. **Declaração da classe estática**

        public static class Rota_DELETE 
        {
   

A classe Rota_DELETE é estática e serve para organizar a rota DELETE da API.

3. **Método de extensão para o WebApplication:**

          public static void MapDeleteRoutes(this WebApplication app)
        {
   

Este método é uma extensão para a classe WebApplication do ASP.NET Core. Usar o this WebApplication app permite que você chame esse método diretamente sobre uma instância do WebApplication (no Program.cs), para adicionar rotas ao pipeline da aplicação.

4. **Definição da rota DELETE**

         app.MapDelete("/tarefas/{id}", async (int id, AppDbContext context) =>
        {
   

`app.MapDelete` cria um endpoint que responde a requisições HTTP DELETE. "/tarefas/{id}" indica que a URL deve ter a forma /tarefas/algumNumero, onde algumNumero será capturado e usado como o parâmetro id.

`"/tarefas/{id}"` indica que a URL deve ter a forma /tarefas/algumNumero, onde algumNumero será capturado e usado como o parâmetro id.

`async (int id, AppDbContext context) => { ... }` é a função assíncrona que será executada quando a rota for chamada. Essa função recebe:

- `int id`: o valor capturado da URL, que representa o ID da tarefa que queremos deletar.

- `AppDbContext context`: uma instância do contexto do banco de dados, injetada automaticamente pelo ASP.NET Core para acessar os dados.

5. **Busca da tarefa no banco**

        var tarefa = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
   

`context.Tasks` é o DbSet que representa a tabela de tarefas no banco.

`FirstOrDefaultAsync(t => t.Id == id)` busca a primeira tarefa cujo Id seja igual ao parâmetro recebido. Se não encontrar nenhuma, retorna null.

O `await` indica que essa é uma operação assíncrona, não bloqueia a thread e espera o resultado da consulta ao banco.

6. **Verificação se a tarefa existe**

        if (tarefa == null)
        return Results.BadRequest("Tarefa não encontrada.");
   

Se a tarefa buscada for null, significa que não existe tarefa com aquele ID.

O método então retorna uma resposta HTTP 400 (BadRequest), com uma mensagem clara dizendo que a tarefa não foi encontrada.

Esse código poderia retornar 404 (NotFound) também, mas aqui optou-se por 400.

7. **Remoção da tarefa**

        context.Tasks.Remove(tarefa);
   

Marca a entidade tarefa para remoção do banco de dados.

Essa operação ainda não aplica a exclusão no banco, só sinaliza que essa tarefa deve ser removida.

8. **Persistência da exclusão**

        await context.SaveChangesAsync();
   

Executa a operação no banco de dados de forma assíncrona, aplicando todas as mudanças pendentes (nesse caso, a remoção da tarefa).

O `await` garante que a operação seja concluída antes de continuar.

9. **Resposta para o cliente**

        return Results.Ok("Tarefa deletada com sucesso.");
   

Retorna um código HTTP 200 OK, que indica sucesso na operação.

A resposta inclui uma mensagem simples confirmando que a tarefa foi deletada com sucesso.
