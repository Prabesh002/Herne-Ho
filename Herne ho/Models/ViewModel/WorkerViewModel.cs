using Herne_ho.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Herne_ho.Models.ViewModel
{
    public class WorkerViewModel
    {
        
        public Guid WorkerId { get; set; }

        public string WorkerName { get; set; } = string.Empty;

        public WorkerType WorkerType { get; set; }

        public string? WorkerEmail { get; set; }

        public string? WorkerPhone { get; set; }


    }
}
