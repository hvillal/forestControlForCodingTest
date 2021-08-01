using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Services
{
    public interface IDroneResources
    {
        public List<DroneOutput> ProcessDronesInstructions(ForestControl forestControl);
    }
}
