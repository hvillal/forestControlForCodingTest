using FirstAPI.Models;
using System.Collections.Generic;
using System;

namespace FirstAPI.Helpers
{
    public static class DroneActionExtensions
    {
        public static ICollection<DroneAction> GetDroneActions(this string droneActions)
        {
            List<DroneAction> actionList = new List<DroneAction>();
            char[] actions = droneActions.ToUpper().ToCharArray();

            foreach (var item in actions)
            {
                actionList.Add((DroneAction)item);
            }

            return actionList;
        }
    }
}
