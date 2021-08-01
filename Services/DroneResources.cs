using AutoMapper;
using FirstAPI.Helpers;
using FirstAPI.Models;
using System;
using System.Collections.Generic;

namespace FirstAPI.Services
{
    public class DroneResources : IDroneResources
    {
        private readonly IMapper _mapper;
        private readonly List<char> _directions = new List<char>() { 'N', 'E', 'S', 'W' };

        public DroneResources(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Main method that moves drones inside the perimeter according to the received instructions.
        /// Drones can move forward, turn to the left and to the right, and they cannot flight outside the perimeter.
        /// </summary>
        /// <param name="forestControl"></param>
        /// <returns>A list of drones with their final location.</returns>
        public List<DroneOutput> ProcessDronesInstructions(ForestControl forestControl)
        {
            List<DroneOutput> drones = new List<DroneOutput>();

            var perimeter = forestControl.Area.GetPerimeter();

            foreach (DroneInput droneNew in forestControl.Drones)
            {
                var drone = _mapper.Map<Drone>(droneNew);
                drone.FinalPosition = new DronePosition
                {
                    Direction = drone.InitialPosition.Direction,
                    PositionX = drone.InitialPosition.PositionX,
                    PositionY = drone.InitialPosition.PositionY
                };

                if (!Enum.IsDefined(typeof(CardinalPoint), drone.InitialPosition.Direction))
                {
                    throw new ArgumentOutOfRangeException("Please check cardinal directions of drones.");
                }

                if (drone.InitialPosition.PositionX > perimeter.Width || drone.InitialPosition.PositionY > perimeter.Height)
                {
                    throw new ArgumentOutOfRangeException($"Please check the initial position of drones: Perimeter {perimeter.Width}x{perimeter.Height}");
                }

                foreach (var action in drone.Actions)
                {
                    if (action == DroneAction.Move)
                    {
                        switch (drone.FinalPosition.Direction)
                        {
                            case CardinalPoint.North:
                                drone.FinalPosition.PositionY++;
                                break;
                            case CardinalPoint.East:
                                drone.FinalPosition.PositionX++;
                                break;
                            case CardinalPoint.South:
                                drone.FinalPosition.PositionY--;
                                break;
                            case CardinalPoint.West:
                                drone.FinalPosition.PositionX--;
                                break;
                            default:
                                break;
                        }

                        if (drone.FinalPosition.PositionX > perimeter.Width || drone.FinalPosition.PositionY > perimeter.Height)
                            throw new ArgumentException($"Drones cannot flight outside the perimeter ({perimeter.Width}x{perimeter.Height}).");
                    }
                    else
                    {
                        if (Enum.IsDefined(typeof(DroneAction), action))
                        {
                            var position = _directions.IndexOf(drone.FinalPosition.Direction.ToString()[0]);

                            if (action == DroneAction.Left)
                                position--;
                            else
                                position++;

                            if (position > _directions.Count - 1)
                                position = 0;
                            else if (position < 0)
                                position = _directions.Count - 1;

                            drone.FinalPosition.Direction = (CardinalPoint)_directions[position].ToString()[0];
                        }
                        else
                            throw new ArgumentOutOfRangeException("Please check drones actions.");
                    }
                }

                var droneToReturn = _mapper.Map<DroneOutput>(drone);
                drones.Add(droneToReturn);
            }

            return drones;
        }
    }
}
