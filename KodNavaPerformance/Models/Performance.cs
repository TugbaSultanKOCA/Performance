using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace KodNavaPerformance.Models
{


    [Table("Performance")]
    public partial class Performance
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public double PerformanceValue { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
