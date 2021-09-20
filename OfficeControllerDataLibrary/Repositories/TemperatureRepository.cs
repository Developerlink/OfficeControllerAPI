using OfficeControllerDataLibrary.Interfaces;
using OfficeControllerModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace OfficeControllerDataLibrary.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly OfficeControllerDbContext _officeControllerDbContext;
        public TemperatureRepository(OfficeControllerDbContext officeControllerDbContext)
        {
            _officeControllerDbContext = officeControllerDbContext;
        }

        public bool AddTemperature(Temperature temperature)
        {
            try
            {
                _officeControllerDbContext.Temperature.Attach(temperature);
                _officeControllerDbContext.Entry(temperature).State = EntityState.Added;
                return Save();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public ICollection<Temperature> GetTemperatures()
        {
            try
            {
                ICollection<Temperature> temperatures = _officeControllerDbContext.Temperature.Include(t => t.TempScale).Include(t => t.Room).ToList();
                return temperatures;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new List<Temperature>();
            }
        }

        public bool Save()
        {
            try
            {
                var rowsChanged = _officeControllerDbContext.SaveChanges();
                return rowsChanged >= 0;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
