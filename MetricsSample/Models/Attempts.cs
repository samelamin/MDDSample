using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetricsSample.Models
{
    public class Attempts
    {
        public Attempts()
        {
            CheckoutAttempt = 1000;
            SuccessfulCheckout = 830;

            PaymentAttempt = 1000;
            SuccessfulPayment = 720;
        }
        public int CheckoutAttempt { get; set; }
        public int SuccessfulCheckout { get; set; }

        public int PaymentAttempt { get; set; }
        public int SuccessfulPayment { get; set; }

    }
}