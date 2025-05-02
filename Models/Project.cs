using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_task1.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
    }
}
