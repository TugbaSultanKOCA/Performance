using KodNavaPerformance.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Web;

namespace KodNavaPerformance.Service
{
    public class NETWORKPerformance
    {

        //Cpu 30 sn db ekleyen bir metod yazılacak.
        public Performance InsertPerformance(Performance performance)
        {
            DataContext db = new DataContext();
            performance.CreationTime = DateTime.Now;
            performance.TypeId = 2;
            db.Performance.Add(performance);
            db.SaveChanges();
            return performance;
        }
        //Dk bir çalışan yazılım nmetodlarını incele.
        //30 sn. kontrol kaydı yapan metodu yaz.
        public Performance GetNetworkCounter()
        {
         
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            WebClient webClient = new WebClient();
            
            //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            double starttime = Environment.TickCount;
            webClient.DownloadData("http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.js");
            double endtime = Environment.TickCount;



            // how many seconds did it take?

            // we are calculating this by subtracting starttime from endtime

            // and dividing by 1000 (since the tickcount is in miliseconds.. 1000 ms = 1 sec)

            double secs = Math.Floor(endtime - starttime) / 1000;
            double secs2 = Math.Round(secs, 0);

            double kbsec = Math.Round(1024 / secs);
            //string time = Convert.ToString(stopwatch.Elapsed);
            //double timeInSecond = TimeSpan.Parse(time).TotalSeconds;
            //int speed = 10240 / Convert.ToInt32(timeInSecond);
            //stopwatch.Stop();
            //stopwatch.Reset();
            var entity = InsertPerformance(new Performance
            {

                PerformanceValue = kbsec
            });
            return entity;
        }
    }
}