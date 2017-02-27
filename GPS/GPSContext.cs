using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS
{
    public class GPSGraph : Graph<GPSNode, GPSStreet>
    {
        [Key]
        public int GPSGraphId { get; set; }

        public override void SaveChanges()
        {
            Program.DbContext.Entry(this).State = EntityState.Modified;
            Program.DbContext.SaveChanges();
        }
    }
    class GPSContext : DbContext
    {
        public DbSet<GPSGraph> Graphs { get; set; }
    }
}
