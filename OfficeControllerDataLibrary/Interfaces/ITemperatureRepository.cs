using OfficeControllerModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeControllerDataLibrary.Interfaces
{
    public interface ITemperatureRepository
    {
        bool AddTemperature(Temperature temperature);
        ICollection<Temperature> GetTemperatures();
    }
}
