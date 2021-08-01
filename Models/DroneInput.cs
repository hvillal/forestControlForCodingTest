using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class DroneInput
    {
        [Required]
        public string InitialPosition { get; set; }
        [Required]
        public string Actions { get; set; }
    }
}
