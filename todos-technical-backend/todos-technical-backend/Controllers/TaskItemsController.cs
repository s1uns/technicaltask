using BLL.Services;
using Infrustructure.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace todos_technical_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemsService _taskItemsService;

        public TaskItemsController(ITaskItemsService taskItemsService)
        {
            _taskItemsService = taskItemsService;
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetTaskItems()
        {
            try
            {
                var result = await _taskItemsService.GetItems();

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTaskItem([FromBody] CreateTaskDto taskDto)
        {
            try
            {
                var result = await _taskItemsService.AddItem(taskDto.Text);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CheckTaskItem(string id)
        {
            try
            {
                var result = await _taskItemsService.CheckItem(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
