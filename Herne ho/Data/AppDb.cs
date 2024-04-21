using Herne_ho.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Herne_ho.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }
       
        public DbSet<WorkerModel> WorkerModels { get; set; }
    }
}
