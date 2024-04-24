using System.ComponentModel.DataAnnotations;

namespace Herne_ho.Models.Entities
{
  

    public class ClientModel
    {
        [Required]
        [Key] public Guid ClientId { get; set; }

        [Required]
        public string ClientName { get; set; }
       
        public string? CLientPhone { get; set; }

        public string ClientEmail { get; set; }

        public List<WorkerModel>? HiredWorker { get; set; }
    }
}
