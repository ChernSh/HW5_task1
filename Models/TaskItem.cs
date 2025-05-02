using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_task1.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        public enum TaskStatus
        {
            NotStarted,
            InProgress,
            Completed
        }
        public TaskStatus Status { get; set; }
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
