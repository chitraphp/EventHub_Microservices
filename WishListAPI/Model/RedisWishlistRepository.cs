﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishListAPI.Model
{
     public class RedisWishlistRepository : IWishlistRepository
     {
         private readonly ILogger<RedisWishlistRepository> _logger;

         private readonly ConnectionMultiplexer _redis;
         private readonly IDatabase _database;
        private int EventId;

         public RedisWishlistRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
         {
             _logger = loggerFactory.CreateLogger<RedisWishlistRepository>();
             _redis = redis;
             _database = redis.GetDatabase();
         }
         public async Task<bool> DeleteWishlistAsync(string id)
         {
             return await _database.KeyDeleteAsync(id);
         }

         public IEnumerable<string> GetUsers()
         {
             var server = GetServer();
             var data = server.Keys();
             return data?.Select(k => k.ToString());
         }

         public async Task<Wishlist> GetWishlistAsync(string customerId)
         {
             var data = await _database.StringGetAsync(customerId);
             if (data.IsNullOrEmpty)
             {
                 return null;
             }

             return JsonConvert.DeserializeObject<Wishlist>(data);
         }

         public async  Task<Wishlist> UpdateWishlistAsync(Wishlist basket)
         {
            _logger.LogInformation("Wishlist being saved is: ", basket.BuyerId, basket.Items);
            var created = await _database.StringSetAsync(basket.BuyerId, JsonConvert.SerializeObject(basket));
             if (!created)
             {
                 _logger.LogInformation("Problem occur persisting the item.");
                 return null;
             }

             _logger.LogInformation("Basket item persisted succesfully.");

             return await GetWishlistAsync(basket.BuyerId);
         }
         private IServer GetServer()
         {
             var endpoint = _redis.GetEndPoints();
             return _redis.GetServer(endpoint.First());
         }

        public async void SetEventIdFromMessaging(int eventId, string buyerId )
        {
            var data = await GetWishlistAsync(buyerId);
            //var response = JsonConvert.DeserializeObject<Wishlist>(data.ToString());

            if (data != null && data.Items.Count > 0)
            {
                foreach (var item in data.Items)
                {
                    if (item.productId == eventId.ToString())
                    {
                        item.IsRegistered = true;


                    }
                }
                await _database.StringSetAsync(buyerId, JsonConvert.SerializeObject(data));
            }
        }

        public async Task<string> GetEventIdFromMessaging(string eventKey)
        {
            
            var data = await _database.StringGetAsync(eventKey);
            
            return data;
        }
     }
}
