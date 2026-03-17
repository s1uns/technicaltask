using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace DAL.Repository
{
    public interface IRepository
    {
        public Task<TaskItem> AddItem(string text);
        public Task<TaskItem> CheckItem(string id);
        public Task<List<TaskItem>> GetItems();
    }
}
