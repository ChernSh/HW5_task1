using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_task1.Models
{
    public class TaskAttachment
    {
        public int Id { get; set; }

        [Required]
        public string FilePath { get; set; }

        public int TaskItemId { get; set; }
        public virtual TaskItem TaskItem { get; set; }
    }

}
