using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public bool IsCompleted { get; set; }
        public string Text { get; set; }
    }
}
