using SQLite;
using System.ComponentModel.DataAnnotations;

namespace DeliveryManager.App.Model
{
    public class Package
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public double Weight { get; set; }
    }

}
