using System.ComponentModel.DataAnnotations;

namespace Herne_ho.Models.Entities
{

    public enum WorkerType
    {
        plumber,
        electrician,
        engineer,
        painter
    }

    public class WorkerModel
    {
        [Key]
        public Guid WorkerId { get; set; }

        [Required]
        public string WorkerName { get; set; } = string.Empty;

        [Required]
        public WorkerType WorkerType { get; set; }

        public string? WorkerEmail { get; set; }

        public string? WorkerPhone { get; set; }


    }
}
