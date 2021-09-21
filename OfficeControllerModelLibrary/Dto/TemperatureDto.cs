using OfficeControllerModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeControllerModelLibrary.Dto
{
    public class TemperatureDto
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int RoomId { get; set; }
        public int TempScaleId { get; set; }

        public TemperatureDto()
        {

        }

        public TemperatureDto(Temperature temperature)
        {
            Id = temperature.Id;
            Value = temperature.Value;
            RoomId = temperature.RoomId;
            TempScaleId = temperature.TempScaleId;
        }
    }
}
