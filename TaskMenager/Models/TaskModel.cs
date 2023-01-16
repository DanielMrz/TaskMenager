using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMenager.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [DisplayName("Numer zadania")]
        [Key]
        public int TaskId { get; set; }
        [DisplayName("Tytuł")]
        [Required(ErrorMessage = "Pole tytuł jest wymagane!")]
        [MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [MaxLength(2000)]
        public string Description { get; set; }
        public bool Done { get; set; }

    }
}
