using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [EnumDataType(typeof(Enums.TaskStatus))]
        public Enums.TaskStatus Status { get; set; }
    }
}
