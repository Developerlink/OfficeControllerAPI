using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeControllerModelLibrary.Models
{
public    class Temperature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Value { get; set; }
        public int RoomId { get; set; }
        public int TempScaleId { get; set; }

        public virtual Room Room { get; set; }
        public virtual TempScale TempScale { get; set; }
    }
}
