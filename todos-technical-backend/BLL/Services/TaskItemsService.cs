using Core.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL.Services
{
    public class TaskItemsService : ITaskItemsService
    {
        private readonly IRepository _repository;

        public TaskItemsService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskItem> AddItem(string text)
        {
            try
            {
                var newItem = await _repository.AddItem(text);
                return newItem;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TaskItem> CheckItem(string id)
        {
            try
            {
                var newItem = await _repository.CheckItem(id);
                return newItem;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<TaskItem>> GetItems()
        {
            return await _repository.GetItems();
        }
    }
}
