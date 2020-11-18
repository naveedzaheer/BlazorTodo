using Blazor.Todo.Server.Data;
using Blazor.Todo.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Todo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TodoItemsController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.TodoItems.ToListAsync();
            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.TodoItems.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoItem todoItem)
        {
            _context.Add(todoItem);
            await _context.SaveChangesAsync();
            return Ok(todoItem.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TodoItem todoItem)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = new TodoItem { Id = id };
            _context.Remove(todoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
