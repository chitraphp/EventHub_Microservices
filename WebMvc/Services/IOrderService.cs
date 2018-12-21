﻿
using WebMvc.ViewModels;
using WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models.Order;

namespace WebMvc.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        //Task<List<Order>> GetOrdersByUser(ApplicationUser user);
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
        //  Order MapUserInfoIntoOrder(ApplicationUser user, Order order);
        //  void OverrideUserInfoIntoOrder(Order original, Order destination);
        //Needed for Displaying Orders
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersByBuyerAsync(string buyerId, int page, int take);
     
    }
}