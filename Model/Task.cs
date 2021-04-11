using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Model
{
    public class Task
    {
        public int Id { get; set; } = 0;
        public string Content { get; set; } = "";

        public int Priority { get; set; } = 0;

        public string CreatedAt { get; set; } = "";
    }
}