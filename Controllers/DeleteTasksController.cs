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