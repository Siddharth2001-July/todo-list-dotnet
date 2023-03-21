using System.ComponentModel.DataAnnotations;

namespace todo_list.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? doneOn { get; set; }
    }
}
