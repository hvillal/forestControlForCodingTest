﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
    public class Drone
    {
        public DronePosition InitialPosition { get; set; }
        public ICollection<DroneAction> Actions { get; set; }
        public DronePosition FinalPosition { get; set; }
    }
}
