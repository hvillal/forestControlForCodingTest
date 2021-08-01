using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Helpers
{
    public static class AreaExtensions
    {
        public static FlightArea GetPerimeter(this string perimeter)
        {
            FlightArea flightArea;
            string[] area = perimeter.Split(' ');

            try
            {
                flightArea = new FlightArea { Width = Convert.ToInt32(area[0]), Height = Convert.ToInt32(area[1]) };
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Please check the perimeter submitted: {ex.Message}");
            }

            return flightArea;
        }
    }
}
