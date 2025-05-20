# TodoList (Delete Task)

### Estrutura do código

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
            return BadRequest("Tarefa não encontrada.");

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return Ok("Tarefa deletada com sucesso.");
    }

### Função

O método DELETE em uma API serve para apagar algo do sistema. No caso de uma lista de tarefas, ele exclui uma tarefa específica do banco de dados. Quando o cliente envia uma requisição DELETE, ele informa o ID da tarefa que quer apagar. Por exemplo: `DELETE /api/tasks/3`. A API procura essa tarefa. Se não achar, responde que ela não existe. Se encontrar, remove do banco e confirma que deu certo. Esse método faz parte do básico de uma API RESTful, junto com GET, POST e PUT. Ele garante que dados possam ser excluídos com clareza e segurança.

### Método DELETE
***`DeleteTasksController`***

1. **Definir o tipo de requisição HTTP**

    [HttpDelete("{id}")]

Especifica que o método será acionado por uma requisição `HTTP DELEET`. O `{id}`indica que o valor será passado na URL, exemplo: `DELETE/api/tasks/5` - onde `5`é o ID da tarefa.

2. **Criar o método assíncrono que deleta a tarefa**

    public async Task<ActionResult> DeleteTask(int id)

Define um método que recebe o `id` da tarefa. Retorna um `ActionResult`, permitindo diferentes respostas HTTP. O uso de `async` permite que a operação com o banco não trave a aplicação.

3. **Buscar a tarefa no banco de dados**

    var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

Procura a tarefa com o ID correspondente na tabela `Tasks`. Se não encontrar, `task` será `null`.

4. **Verificar se a tarefa existe**

    if (task == null)
    return BadRequest("Tarefa não encontrada.");

Se a tarefa não existir, retorna um erro HTTP 400 com a mensagem. Informa que a exclusão não pode ser feita porque a tarefa não existe.

5. **Remover a tarefa do banco**

    _context.Tasks.Remove(task);

Marca a tarefa para ser removida do banco.

6. **Salvar alterações no banco**

    await _context.SaveChangesAsync();

Aplica a exclusão de forma definitiva no banco de dados. Usa `await` para garantir que a operação seja concluída antes de continuar.

7. **Retornar mensagem de sucesso**

    return Ok("Tarefa deletada com sucesso.");

Retorna um código HTTP 200 OK com uma mensagem de confirmação. Informa que a tarefa foi excluída com sucesso.