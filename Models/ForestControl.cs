using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    /// <summary>
    /// Contains information about perimeter and drones
    /// </summary>
    public class ForestControl
    {
        /// <summary>
        /// Perimeter for drones
        /// </summary>
        [Required]
        public string Area { get; set; }
        
        /// <summary>
        /// Drones' information
        /// </summary>
        [Required]
        public ICollection<DroneInput> Drones { get; set; }
    }
}
