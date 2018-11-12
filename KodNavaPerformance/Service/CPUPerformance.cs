using KodNavaPerformance.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace KodNavaPerformance.Service
{
    public  class CPUPerformance
    {

        //Cpu 30 sn db ekleyen bir metod yazılacak.
        public  Performance InsertPerformance(Performance performance)
        {
            DataContext db = new DataContext();
            performance.CreationTime = DateTime.Now;
            performance.TypeId = 1;
            db.Performance.Add(performance);
            db.SaveChanges();
            return performance;
        }
        //Şuan ki performance değerini alan metod yazılacak.
        //Dk bir çalışan yazılım nmetodlarını incele.
        //30 sn. kontrol kaydı yapan metodu yaz. InsertPerformance tetikleyecek.
    
       
        public Performance getCPUCounter()
        {

            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            // will always start at 0
            dynamic firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();
            var entity= InsertPerformance(new Performance
            {
                PerformanceValue = secondValue
            }
            );
            return entity;
        }
     
 

    }
}
