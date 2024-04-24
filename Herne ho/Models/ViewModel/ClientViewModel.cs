using Herne_ho.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Herne_ho.Models.ViewModel
{
    public class ClientViewModel
    {
        public Guid ClientId { get; set; }

        public string ClientName { get; set; }

        public string? CLientPhone { get; set; }

        public string ClientEmail { get; set; }

        public List<WorkerModel>? HiredWorker { get; set; }
    }
}
