using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;


namespace BLL.Services
{
    public interface ITaskItemsService
    {
        public Task<TaskItem> AddItem(string text);
        public Task<TaskItem> CheckItem(string id);
        public Task<List<TaskItem>> GetItems();
    }
}
