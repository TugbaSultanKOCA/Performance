using KodNavaPerformance.Models;
using KodNavaPerformance.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KodNavaPerformance.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        CPUPerformance cpuPer = new CPUPerformance();
        NETWORKPerformance networkPer = new NETWORKPerformance();
        public ActionResult Index()
        {
            PerformanceViewModel model = new PerformanceViewModel();
            model.Performances.Add(cpuPer.getCPUCounter());
            model.Performances.Add(networkPer.GetNetworkCounter());
            return View(model);
        }

        public ActionResult List()
        {
            var entity = db.Performance.OrderByDescending(x => x.CreationTime).Take(100).ToList();

            return View(entity);
        }
        public JsonResult CheckLastPerformance()
        {

            var cpu = db.Performance.Where(x => x.TypeId == 1).OrderByDescending(x => x.CreationTime).FirstOrDefault();

            var network = db.Performance.Where(x => x.TypeId ==2).OrderByDescending(x => x.CreationTime).FirstOrDefault();

            var newCpuValue = cpuPer.getCPUCounter();
            var newNetwork = networkPer.GetNetworkCounter();
            var messageCpu = "";
            var messageNetwork = "";
            if (newCpuValue.PerformanceValue<cpu.PerformanceValue)
            {
                messageCpu += String.Format("New Cpu Value: {0} Last Cpu Value : {1} is Lower", newCpuValue.PerformanceValue, cpu.PerformanceValue);
            }
            if (newNetwork.PerformanceValue < network.PerformanceValue)
            {
                messageNetwork += String.Format("New Network Value: {0} Last Network Value : {1} is Lower", newNetwork.PerformanceValue, network.PerformanceValue);
            }
            return Json( new { messagecpu=messageCpu, messagenetwork=messageNetwork, lastcpu = newCpuValue.PerformanceValue, lastnetwork = newNetwork.PerformanceValue }, JsonRequestBehavior.AllowGet);
        }
       
    }
}
