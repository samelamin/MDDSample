using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                    client.Send("attempts", i);

                    Random random = new Random();
                    if ((sample.SuccessfulCheckout > i) && random.Next(1,15) >= 3)
                        client.Send("successful", i);

                    i++;
                    Thread.Sleep(250);
                }
            }



            using (var client = new GraphiteTcpClient("54.78.137.100", 2003, "checkoutservice"))
            {
                int i = 0;
                while (i < sample.PaymentAttempt)
                {
                    client.Send("attempts", i);

                    Random random = new Random();
                    if ((sample.SuccessfulPayment > i) && random.Next(1, 15) >= 3)
                        client.Send("successful", i);

                    i++;
                    Thread.Sleep(250);
                }
            }

            return View("Index");
        }
    }
}