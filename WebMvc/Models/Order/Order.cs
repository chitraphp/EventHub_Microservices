﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Models.Order
{
    public class Order
    {     
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public DateTime OrderDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal OrderTotal { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [BindNever]
        public string UserName { get; set; }

        [BindNever]
        public string BuyerId { get; set; }

        public string StripeToken { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public int NumTotalTickets { get; set; }

        public List<OrderTicket> OrderTickets { get; set; } = new List<OrderTicket>();

        //EventProperties
        public int EventId { get; set; }

        public string EventTitle { get; set; }

        public DateTime EventStartDate { get; set; }

        public DateTime EventEndDate { get; set; }

        public string PictureUrl { get; set; }

        public string PaymentAuthCode { get; set; }

        public List<OrderTicket> OrderTicket { get; } = new List<OrderTicket>();
    }

    public enum OrderStatus
    {
        Preparing = 1,
        Shipped = 2,
        Delivered = 3,
        Canceled = 4
    }

}
