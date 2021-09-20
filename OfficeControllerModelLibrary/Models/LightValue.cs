using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeControllerModelLibrary.Models
{
    public class LightValue
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
