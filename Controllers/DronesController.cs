using AutoMapper;
using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("drone")]
    public class DronesController : ControllerBase
    {
        private readonly IDroneResources _droneResources;

        public DronesController(IDroneResources droneResources)
        {
            _droneResources = droneResources ?? throw new ArgumentNullException(nameof(droneResources));
        }

        /// <summary>
        /// Process information submitted about perimeter and drones.  
        /// </summary>
        /// <param name="forestControl">Information about perimeter, and for drones: initial position and actions.</param>
        /// <returns>Final position of each drone.</returns>
        /// <remarks>
        /// Area: Perimeter (Width x Height). \
        /// InitialPosition: Set the initial position of drone (X Y Cardinal direction). \
        /// Actions: Rotate o move forward. \
        /// \
        /// Actions availables for drones: \
        /// L => Rotate to the left \
        /// R => Rotate to the right \
        /// M => Move forward \
        /// \
        /// Sample request \
        /// POST
        /// [ 
        ///     { 
        ///         "area": "5 5",
        ///         "drones": [
        ///             {
        ///                 "initialPosition": "3 3 E",
        ///                 "actions": "L"
        ///             },
        ///             {
        ///                 "initialPosition": "3 3 E",
        ///                 "actions": "MMRMMRMRRM"
        ///             }
        ///     }
        /// ]
        /// </remarks>
        [HttpPost]
        public ActionResult<IEnumerable<Drone>> Get([FromBody] ForestControl forestControl)
        {
            List<DroneOutput> drones = new List<DroneOutput>();

            try
            {
                drones = _droneResources.ProcessDronesInstructions(forestControl);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is ArgumentOutOfRangeException || ex is AutoMapperMappingException || ex is NullReferenceException)
                    return BadRequest(ex.Message);

                throw;
            }

            return Ok(drones);
        }
    }
}
