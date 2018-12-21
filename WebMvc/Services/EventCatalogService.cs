﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;
using WebMvc.Services;

namespace WebMvc.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;

        private readonly IHttpClient _apiClient;

        private readonly string _remoteServiceBaseUrl;

      


        public EventCatalogService(IOptionsSnapshot<AppSettings> settings,

            IHttpClient httpClient)

        {

            _settings = settings;

            _apiClient = httpClient;

               _remoteServiceBaseUrl = $"{_settings.Value.EventCatalogUrl}/api/event/";
       
        }

        public async Task<IEnumerable<SelectListItem>> GetEventCategories()
        {
            
            var getEventCategoriesUri = ApiPaths.EventCatalog.GetAllEventCategories(_remoteServiceBaseUrl);
            var dataString = await _apiClient.GetStringAsync(getEventCategoriesUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
             };

            var categories = JArray.Parse(dataString);
            foreach (var category in categories.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = category.Value<string>("id"),
                    Text = category.Value<string>("name")
                });
            }
            return items;
        }

        public async Task<EventCategoryCatalog> GetEventCategoriesWithImage(int page, int take)
        {
            var getEventCategoriesUri = ApiPaths.EventCatalog.GetAllEventCategoriesForImage(_remoteServiceBaseUrl, page, take);
            var dataString = await _apiClient.GetStringAsync(getEventCategoriesUri);          
            var response = JsonConvert.DeserializeObject<EventCategoryCatalog>(dataString);

            return response;
        }

        public async Task<List<EventCategory>> GetEventCategoriesForHashTag()
        {
            var getEventCategoriesUri = ApiPaths.EventCatalog.GetAllEventCategories(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getEventCategoriesUri);

            //  var categories = JArray.Parse(dataString);
            var categories = JsonConvert.DeserializeObject<List<EventCategory>>(dataString);

           // var response = JsonConvert.DeserializeObject<EventCategoryCatalog>(dataString);

            return categories;
        }


        public async Task<EventCatalog> GetEvents(int page, int take, int? category, int? type)
        {

            var alleventsUri = ApiPaths.EventCatalog.GetAllEvents(_remoteServiceBaseUrl, page, take, category, type);
            var dataString = await _apiClient.GetStringAsync(alleventsUri);
            var response = JsonConvert.DeserializeObject<EventCatalog>(dataString);

            return response;
        }

        public async Task<EventCatalog> GetEventsWithTitle(string title, int page, int take)
        {
            var eventswithtitleUri = ApiPaths.EventCatalog.GetEventsWithTitle(_remoteServiceBaseUrl,title,page, take);
            var dataString = await _apiClient.GetStringAsync(eventswithtitleUri);
            var response = JsonConvert.DeserializeObject<EventCatalog>(dataString);
            return response;
        }

        public async Task<EventCatalog> GetEventsWithTitleCityDate(string title, string city, string date, int page, int take)
        {

            var eventswithtitleUri = ApiPaths.EventCatalog.GetEventsWithTitleCityDate(_remoteServiceBaseUrl, title, city, date, page, take);
            var dataString = await _apiClient.GetStringAsync(eventswithtitleUri);
            var response = JsonConvert.DeserializeObject<EventCatalog>(dataString);

            return response;
        }

        public async Task<Event> GetEventItem(int EventId)
        {
            var getEventDetailUri = ApiPaths.EventCatalog.GetEvent(_remoteServiceBaseUrl, EventId);
            var dataString = await _apiClient.GetStringAsync(getEventDetailUri);
            var item = JsonConvert.DeserializeObject<Event>(dataString);

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetEventTypes()
        {
            var getEventTypesUri = ApiPaths.EventCatalog.GetAllEventTypes(_remoteServiceBaseUrl);
            var dataString = await _apiClient.GetStringAsync(getEventTypesUri);
            var items = new List<SelectListItem>
            {
                   new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = type.Value<string>("id"),
                    Text = type.Value<string>("type")
                });
            }
            return items;
        }

        ////post Event services start- bhuvana
        //public async Task<string> CreateEvent(Event newEvent)
        //{
        //    var getEventDetailUri = ApiPaths.EventCatalog.PostEvent(_remoteServiceBaseUrl);
        //    var dataString = await _apiClient.PostStringAsync(getEventDetailUri);
        //    var Content = "";
        //    var poststring = await _apiClient.PostAsync(getEventDetailUri,Content);

        //    return "";
        //}
        //EventCity Services 
        public async Task<EventCityCatalog> GetCityInfo( string city)
        {
            var allEventsCityUri = ApiPaths.EventCatalog.GetCityDescription(_remoteServiceBaseUrl, city);
            var dataString = await _apiClient.GetStringAsync(allEventsCityUri);
            var response = JsonConvert.DeserializeObject<EventCityCatalog>(dataString);

            return response;

        }
        public async Task<EventCatalog> GetEventsInCity(string city)
        {
            var allEventsCityUri = ApiPaths.EventCatalog.GetCatalogEventsInCity(_remoteServiceBaseUrl, city);
            var dataString = await _apiClient.GetStringAsync(allEventsCityUri);
            var response = JsonConvert.DeserializeObject<EventCatalog>(dataString);
            return response;
        }
        public async Task<IEnumerable<SelectListItem>> GetCities()
        {
            var getCitiesUri = ApiPaths.EventCatalog.GetAllEventCities(_remoteServiceBaseUrl);
            var datastring = await _apiClient.GetStringAsync(getCitiesUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem(){Value = "0",Text = "city",Selected = true}
            };
            var cities = JArray.Parse(datastring);
            foreach (var city in cities.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = city.Value<string>("cityName"),
                    Text = city.Value<string>("cityName")
                });
            }
            return items;
        }
        /*
        public async Task<EventCityCatalog> GetCityWithId(int? cityFilterApplied,string city, int page, int take)
        {
            var allEventsCityUri = ApiPaths.EventCatalog.GetCityDescription(_remoteServiceBaseUrl,cityFilterApplied,city,page,take);
            var dataString = await _apiClient.GetStringAsync(allEventsCityUri);
            var response = JsonConvert.DeserializeObject<EventCityCatalog>(dataString);
            return response;
        }
        public async Task<EventCatalog> GetEventsWithCityId(int? cityFilterApplied,string city, int page, int take)
        {
            var allEventsCityUri = ApiPaths.EventCatalog.GetEventsWithCityId(_remoteServiceBaseUrl, cityFilterApplied,city, page, take);
            var dataString = await _apiClient.GetStringAsync(allEventsCityUri);
            var response = JsonConvert.DeserializeObject<EventCatalog>(dataString);
            return response;
        }*/
        // end - bhuvana
        public async Task<EventCatalog> GetEventsByAllFilters(int page, int take, int? category, int? type, String date, String city)
        {
            var alleventsUri = ApiPaths.EventCatalog.GetEventsByAllFilters(_remoteServiceBaseUrl,  page, take,  category,  type, date, city);
            var dataString = await _apiClient.GetStringAsync(alleventsUri);
            var response = JsonConvert.DeserializeObject<EventCatalog>(dataString);
            return response;
        }
        //chitra
        public async Task<IEnumerable<SelectListItem>> GetAllCities()
        {
            var getAllCitiesUri = ApiPaths.EventCatalog.GetAllCities(_remoteServiceBaseUrl);
            var dataString = await _apiClient.GetStringAsync(getAllCitiesUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var cities = JsonConvert.DeserializeObject<List<string>>(dataString);
            //var cities = JArray.Parse(dataString);
            foreach (var city in cities)
            {
                items.Add(new SelectListItem()
                {
                    Text = city,
                    Value = city.Split(',')[0].ToLower()
                });
            }
            return items;
        }

        public IEnumerable<SelectListItem> GetEventDates()
        {
            List<String> eventDates = new List<string> { "Today", "Tomorrow","This week", "This weekend", "Next week", "Next weekend", "This month", "Next month"};
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = "All Days", Text = "All Days", Selected = true }
            };
            foreach (var eventDate in eventDates)
            {
                items.Add(new SelectListItem()
                {
                    Value = eventDate,

                    Text = eventDate
                });
            }
            return items;
        }

        public async Task<int> CreateEvent(EventForCreation eve)
        {
           // var token = await GetUserTokenAsync();

            var addNewEventUri = ApiPaths.EventCatalog.PostEvent(_remoteServiceBaseUrl);
         //   _logger.LogDebug(" OrderUri " + addNewOrderUri);


            var response = await _apiClient.PostAsync(addNewEventUri, eve);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creating Event, try later.");
            }

            // response.EnsureSuccessStatusCode();
            var jsonString = response.Content.ReadAsStringAsync();

            jsonString.Wait();
          //  _logger.LogDebug("response " + jsonString);
            dynamic data = JObject.Parse(jsonString.Result);
            string value = data.id;
            return Convert.ToInt32(value);
        }


      

    }
}
