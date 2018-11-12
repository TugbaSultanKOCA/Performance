using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KodNavaPerformance.Models
{
    public class PerformanceViewModel
    {
        public PerformanceViewModel()
        {
            Performances = new List<Performance>();
        }
        public List<Performance> Performances { get; set; }
    }
}