using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Model;
using Task = TaskApi.Model.Task;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : ControllerBase
    {
        List<Task> _oTasks = new List<Task>()
        {
            new Task(){Id=1, Content="first obj", Priority=1, CreatedAt="63753732618134"},
            new Task(){Id=2, Content="do some backend dev", Priority=8, CreatedAt="63753732618135"},
            new Task(){Id=3, Content="do some GQL", Priority=3, CreatedAt="63753732618136"},
        };

        //TODO: There should be an endpoint to add a new task, with a name and priority of between 1-10
        [HttpPost]
        public IActionResult Save(Task oTask)
        {
            var dateticks = DateTime.Now.Ticks;
            var res = dateticks / TimeSpan.TicksPerMillisecond;
            oTask.CreatedAt = res.ToString();
            _oTasks.Add(oTask);

            if(_oTasks.Count == 0)
            {
                return NotFound("[INFO] You don't have any tasks");
            }
            if(oTask.Priority < 1 || oTask.Priority > 10)
            {
                return NotFound("[INFO] Priority level out of range, select between 1-10");
            }
            return Ok(_oTasks);
        }

        //TODO: There should be an endpoint to list all tasks by the order they were added to the list
        [HttpGet]
        public IActionResult Gets()
        {
            var descCreated = _oTasks.OrderByDescending(task => task.CreatedAt).ToList();
            if (descCreated == null)
            {
                return NotFound("[INFO] No tasks found..");
            }
            return Ok(descCreated);
        }

        //TODO: There should be an endpoint to list all tasks ordered by priority
        [HttpGet("TaskAsc")]
        public IActionResult GetPriority()
        {
            var ascPriority = _oTasks.OrderBy(task => task.Priority).ToList();
            if(ascPriority == null)
            {
                return NotFound("[INFO] No tasks found..");
            }
            return Ok(ascPriority);

        }

        //TODO: There should be an endpoint to fetch all tasks below a certain priority
        [HttpGet("TaskByPriority")]
        public IActionResult Get(int priority)
        {
            var oTask = _oTasks.FindAll(x => x.Priority > priority);
            if(oTask == null)
            {
                return NotFound("[INFO] No tasks with lower priority found..");
            }
            return Ok(oTask);
        }

        //TODO: There should be an endpoint to remove a task
        [HttpDelete]

        public IActionResult DeleteTask(int id)
        {
            var delTask = _oTasks.SingleOrDefault(x => x.Id == id);
            if(delTask == null)
            {
                return NotFound("[INFO] Task not found..");
            }
            _oTasks.Remove(delTask);

            if (_oTasks.Count == 0)
            {
                return NotFound("[INFO] You don't have any tasks");
            }
            return Ok(_oTasks);
        }
    }
}