using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeControllerModelLibrary.Models
{
public    class Alarm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Value { get; set; }
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
