using FirstAPI.Models;
using System;

namespace FirstAPI.Helpers
{
    public static class DronePositionExtensions
    {
        public static DronePosition GetDronePosition(this string dronePosition)
        {
            DronePosition position;
            string[] drone = dronePosition.Split(' ');

            position = new DronePosition
            {
                PositionX = Convert.ToInt32(drone[0]),
                PositionY = Convert.ToInt32(drone[1]),
                Direction = (CardinalPoint)drone[2].ToUpper()[0]
            };

            return position;
        }
    }
}
