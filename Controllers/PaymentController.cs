using Microsoft.AspNetCore.Mvc;
using Payment_trial.Models;
using Razorpay.Api;
using System;
using System.Collections.Generic;

namespace Payment_trial.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InitiateOrder()
        {
            string key = "rzp_test_k0OzFG7FVPhMJL";
            string secret = "TeFGNd86kcmPv5DaJyGDc7DC";

            Random random = new Random();
            string transactionId = random.Next(0, 10000).ToString();

            PaymentClass paymentDetails = new PaymentClass();

            if (HttpContext.Request.Form["Customername"].Count > 0)
            {
                paymentDetails.Customername = HttpContext.Request.Form["Customername"];
                paymentDetails.Email = HttpContext.Request.Form["Email"];
                paymentDetails.Mobile = HttpContext.Request.Form["Mobile"];
                paymentDetails.TotalAmount = double.Parse(HttpContext.Request.Form["TotalAmount"]);

                Dictionary<string, object> input = new Dictionary<string, object>();

                input.Add("amount", paymentDetails.TotalAmount * 100); // Amount should be in paisa
                input.Add("currency", "INR");
                input.Add("receipt", transactionId);

                RazorpayClient client = new RazorpayClient(key, secret);
                Razorpay.Api.Order order = client.Order.Create(input);
                ViewBag.OrderId = order["id"].ToString();

                // Pass necessary details to the view using ViewBag
                ViewBag.Customername = paymentDetails.Customername;
                ViewBag.Email = paymentDetails.Email;
                ViewBag.Mobile = paymentDetails.Mobile;

                return View("paymentnew", paymentDetails);
            }
            else
            {
                // Handle null _PaymentDetails
                return View("Error");
            }



        }

      
    }
}
