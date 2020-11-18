using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Todo.Shared
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
