using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Graphite;

using MetricsSample.Models;

namespace MetricsSample.Controllers
{
    public class MetricsController : Controller
    {
        // GET: Attempts
        public ActionResult Index()
        {
            return View(new Attempts());
        }

        public ActionResult Checkout(Attempts sample)
        {
            using (var client = new GraphiteTcpClient("54.78.137.100", 2003, "checkoutservice"))
            {
                int i = 0;
                while (i < sample.CheckoutAttempt)
                {
                    i = i + 100;
                    client.Send("attempts", i);
                    if (sample.SuccessfulCheckout > 0)
                        client.Send("successful", i);
                }
            }

            //Thread.Sleep(10000);
            //using (var client = new GraphiteTcpClient("54.78.163.146", 2003, "paymentservice"))
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        client.Send("attempts", 10 * i);
            //        client.Send("successful", 8 * i);
            //        Thread.Sleep(2000);
            //    }
            //}

            return View("Index");
        }
    }
}