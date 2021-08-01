using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
    public class DronePosition
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public CardinalPoint Direction { get; set; }
    }
}
