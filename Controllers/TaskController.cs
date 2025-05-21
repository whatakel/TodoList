using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks; // <-- Adicione esta linha
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TodoTask>> CreateTask([FromBody] TodoTask task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateTask), new { id = task.Id }, task);
        }
    }
}