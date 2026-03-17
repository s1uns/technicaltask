using Core.Models;
using System.Text.Json;

namespace DAL.Repository
{
    public class Repository : IRepository
    {
        private readonly List<TaskItem> _items;

        public Repository()
        {
            _items = [];
        }
        public async Task<TaskItem> AddItem(string text)
        {
            var itemId = Guid.NewGuid().ToString();

            var taskItem = new TaskItem
            {
                Id = itemId,
                IsCompleted = false,
                Text = text
            };

            _items.Add(taskItem);

            return taskItem;
        }

        public async Task<TaskItem> CheckItem(string id)
        {
            var oldItem = _items.Where(item => item.Id == id).FirstOrDefault();
            
            if (oldItem is null)
            {
                throw new Exception("Item not found");
            }

            oldItem.IsCompleted = !oldItem.IsCompleted;

            return oldItem;

        }

        public async Task<List<TaskItem>> GetItems()
        {
            return _items;

        }
    }
}
