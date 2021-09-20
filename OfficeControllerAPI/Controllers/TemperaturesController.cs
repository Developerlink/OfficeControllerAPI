using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeControllerDataLibrary.Interfaces;
using OfficeControllerModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeControllerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TemperaturesController : Controller
    {
        private readonly ITemperatureRepository _temperatureRepository;

        public TemperaturesController(ITemperatureRepository temperatureRepository)
        {
            _temperatureRepository = temperatureRepository;
        }

        // GET: <TemperaturesController>
        [HttpGet]
        public ActionResult<IEnumerable<Temperature>> GetTemperatures()
        {
            var temperatures = _temperatureRepository.GetTemperatures();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (temperatures == null)
            {
                ModelState.AddModelError("", $"Something went wrong trying to retrieve Temperatures");
                return StatusCode(500, ModelState);
            }

            return Ok(temperatures);
        }        

        // POST <TemperaturesController>
        [HttpPost]
        public ActionResult PostTemperature([FromBody] Temperature temperature)
        {
            if (temperature == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // This does not work in this project but it works in others!?
            //Temperature.PostalCode = _postalCodeRepository.GetPostalCode(Temperature.PostalCodeId);

            if (!_temperatureRepository.AddTemperature(temperature))
            {
                ModelState.AddModelError("", $"Something went wrong adding the Temperature");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetTemperatures", new { id = temperature.Id }, temperature);
        }

        
    }
}
