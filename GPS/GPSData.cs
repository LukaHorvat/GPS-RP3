using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GPS
{
    public enum NodeType
    {
        Store,
        PostOffice,
        GasStation,
        Garage,
        Hospital
    }

    [Table("GPSCharacteristic")]
    public class GPSCharacteristic
    {
        [Key]
        public int GPSCharacteristicId { get; set; }
        public NodeType NodeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    [Table("GPSNode")]
    public class GPSNode : ILocated
    {
        [Key]
        public int GPSNodeId { get; set; }
        public PointF Location { get; set; }
        [JsonIgnore]
        public Control AssociatedControl { get; set; }
        public List<GPSCharacteristic> Characteristics { get; set; }
        public string Name { get; set; }
        public GPSNode()
        {
            Characteristics = new List<GPSCharacteristic>();
        }
    }

    [Table("GPSStreet")]
    public class GPSStreet
    {
        [Key]
        public int GPSStreetId;
        [JsonIgnore]
        public Control AssociatedControl { get; set; }
        public List<GPSCharacteristic> Characteristics { get; set; }
        public string Name { get; set; }
        public GPSStreet()
        {
            Characteristics = new List<GPSCharacteristic>();
        }
    }
}
