﻿using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventCatalogSeed
    {
        public static async Task SeedAsync(EventCatalogContext context)
        {
            context.Database.Migrate();

            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange
                    (GetPreconfiguredEventCategories());

                await context.SaveChangesAsync();
            }

            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange
                    (GetPreconfiguredEventTypes());
                context.SaveChanges();
            }

            if (!context.Events.Any())
            {
                context.Events.AddRange
                    (GetPreconfiguredEvents());
                context.SaveChanges();
            }

            if (!context.EventCities.Any())
            {
                context.EventCities.AddRange
                    (GetPreconfiguredEventCities());
                context.SaveChanges();
            }

        }
        private static IEnumerable<EventCity> GetPreconfiguredEventCities()
        {
            return new List<EventCity>()
            {
                new EventCity(){CityName = "Redmond,Washington",CityDescription="Redmond, Washington, is a growing tech and science hub that's all about the latest innovations. This groundbreaking town is the place to be if you're in the mood for fresh air, fresher food, and the freshest ideas. Blast off to fun and check out some of the area events below!",CityImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/City/2"},
                new EventCity(){CityName = "New York, New York",CityDescription="This cultural mecca is loaded with events and things to do. Walk the High Line and drop into the Meatpacking District for galleries and good eats. Shop the West Village. Get your American Art on at the Whitney. Take a breather in Central Park.",CityImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/City/3"},
                new EventCity() { CityName = "Bellevue,Washington", CityDescription = "Looking for something to do in Bellevue? Whether you're a local, new in town or just cruising through we've got loads of great tips and events. You can explore by location, what's popular, our top picks, free stuff... you got this. Ready?", CityImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/City/4" },
                new EventCity() { CityName = "Dallas,Texas",CityDescription = "Yes sir this friendly city keeps it live with hot events, strong margaritas and gas station tacos that are genuinely delish. You'll need to see Big Tex at the Texas State Fair. Two-step with the LGBTQ crowd at the Round-Up Saloon. See something amazing at the Perot Museum of Nature and Science. And eat any version of fried chicken/chicken-fried steak/fried other stuff.",CityImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/City/1"},
                new EventCity() { CityName = "Frederick,Maryland",CityDescription = "Looking for something to do in Frederick,MD? Whether you're a local, new in town or just cruising through we've got loads of great tips and events. You can explore by location, what's popular, our top picks, free stuff... you got this. Ready?",CityImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/City/5"},
                new EventCity() { CityName = "Baltimore,Maryland",CityDescription = "Come to Baltimore. it is the charm city with the best crabs cakes. Go to symphony or the museum. Explore and have fun, learn and meet new people in the friendly city",CityImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/City/5"},
            };

        }


        static IEnumerable<EventCategory> GetPreconfiguredEventCategories()
        {
            return new List<EventCategory>()
            {

                new EventCategory() { Name = "Music", ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/54"},
                new EventCategory() { Name = "Arts", ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/58"},
                new EventCategory() { Name = "Food and Drink", ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/52"},
                new EventCategory() { Name = "Business", ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/51"},
                new EventCategory() { Name = "Health", ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/50"},
                new EventCategory() { Name = "Charity",ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/53"},
                new EventCategory() { Name = "Science and Tech",ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/55"},
                new EventCategory() { Name = "Fashion",ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/57"},
                new EventCategory() { Name = "Sports",ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/60"},
                new EventCategory() { Name = "Film and Media",ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/59"},
                new EventCategory() { Name = "Other",ImageUrl="http://externalcatalogbaseurltobereplaced/api/pic/56"}


            };

        }



        static IEnumerable<EventType> GetPreconfiguredEventTypes()
        {

            return new List<EventType>()
            {

                new EventType() { Type = "Class"},
                new EventType() { Type = "Seminar"},
                new EventType() { Type = "Performance" },
                new EventType() { Type = "Festival" },
                new EventType() { Type = "Gala" },
                new EventType() { Type = "Expo" },
                new EventType() { Type = "Conference" },
                new EventType() { Type = "Screening" },
                new EventType() { Type = "Networking" },
                new EventType() { Type = "Other" }

            };

        }



        static IEnumerable<Event> GetPreconfiguredEvents()

        {

            return new List<Event>()
            {

                new Event() {EventTypeId=1,EventCategoryId=3, Title = "A Night with Katy Perry",  OrganizerId = 1, OrganizerName = "John Snow", Address= "MerryWeather Pavilion", City = "Baltimore", State ="Maryland", Zipcode ="21105", Price = 49.5M, StartDate = new DateTime(2018, 10, 09, 7, 10, 0), EndDate = new DateTime(2018, 10, 10, 9, 15, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "A unique medley of a dance drama featuring: Four styles of Indian classical. music: Carnatic, Hindustani, Abhang, and Folk. Six forms of Indian classical dances: Bharatnatyam blended with shades of Kathakali, Mohiniattam, Kuchipudi, Kathak, and Folk. Songs sung in seven different languages: Sanskrit, Hindi, Marathi, Malayalam, Kannada, Tamil, and Telugu. This event is a fund-raiser for Aim for Seva Seattle. Through our unique chatralaya program, Aim for Seva is transforming education in rural India. We build and maintain these chatralayas (hostels) near existing schools and pay the full boarding, lodging, and tuition expenses for rural under-privileged children. " },

                new Event() {EventTypeId=6,EventCategoryId=5, Title = "Feed the Children Gala", OrganizerId = 2, OrganizerName = "Mandy Murphy", Address= "222 Observation Way", City = "New York City", State ="New York", Zipcode ="10103", Price = 500.0M, StartDate = new DateTime(2018, 9, 27, 20, 30, 0), EndDate = new DateTime(2018, 9, 29, 23, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Using “Yes, and…” and other scene building skills learned in Improv 100, we will create scenes of greater complexity, allowing the basics to provide a foundation to build on, furthering your improv skills and the quality of your spontaneous storytelling through improvised scenes. We will also be using more of the games that you see regularly in a Theatresports(TM) match.Discover the concepts beyond the entertainment value of the games and what lies behind the rules that release emotional investment, further narrative skills and help spontaneously create the imaginary circumstances that believable characters inhabit." },

                new Event() {EventTypeId=7,EventCategoryId=1, Title = "Learn Python for Free", OrganizerId = 3, OrganizerName = "Sam Smith", Address= "150 Tech Circle", City = "Redmond", State ="Washington", Zipcode ="98117", Price = 0.0M, StartDate = new DateTime(2018, 10, 10, 12, 0, 0), EndDate = new DateTime(2018, 10, 8, 12, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Hone your painting skills and expand your creative language in this unique three-day workshop experience with award-winning contemporary American Impressionist Eric Jacobsen. Emphasis will be on risk-taking, abstract design and mark making… three necessary components to take your work to the next level and separate yourself from the “pack”. Learn to see like a poet and unlock your true creative potential. Come to take a journey into new artistic territory… open up the possibility for a more pure, honest and unique result for your paintings. What are you waiting for… sign up now." },

                new Event() {EventTypeId=3,EventCategoryId=4, Title = "Burger Fest", OrganizerId = 4, OrganizerName = "Mark Harmon", Address= "237 Long Horn Drive", City = "Dallas", State ="Texas", Zipcode ="78110", Price = 0.0M, StartDate = new DateTime(2018, 9, 27, 9, 0, 0), EndDate = new DateTime(2018, 9, 27, 17, 30, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Welcoming students of all ages and abilities, artist C J Elsip combines a versatile, inspirational and intuitive approach with an extensive variety of effective drawing and painting techniques, encouraging you to stretch the boundaries of both creative medium and mind to discover, explore and develop your own personal, creative language.  Through hands on demonstration and individual guidance, discover time-honored, traditional and experimental drawing and painting techniques as you are guided on a fascinating creative journey of light, color, composition and depth. This class specialises in oil painting, but you can also work in acrylic or watercolour as you wish. Choose your own subject matter, medium, palette and painting round in this class. C J Elsip will guide and advise you step-by-step through planning, use of materials, colour mixing and ultimately creating your very own masterpieces in your own unique style.Classes are small to ensure maximum individual attention throughout. " },

                new Event() {EventTypeId=2,EventCategoryId=3, Title = "Death of a Salesman", OrganizerId = 5, OrganizerName = "Bethany Black", Address= "Washington State Theater", City = "Bellvue", State ="Washington", Zipcode ="98006", Price = 34.99M, StartDate = new DateTime(2018, 11, 23, 20, 0, 0), EndDate = new DateTime(2018, 11, 23, 22, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Social Ballroom dance class for beginners from one of the US top DanceSport program - NIKA International Academy! We learn basics of the most popular dances: Salsa, Foxtrot, Rumba, Waltz, ECSwing and Tango. No partner or experience necessary!!" },

                new Event() {EventTypeId=5,EventCategoryId=7, Title = "Tropical Epedimelogy 2018", OrganizerId = 6, OrganizerName = "Cherry Sweet", Address= "349 Hospital Blvd", City = "Redmond", State ="Washington", Zipcode ="98118", Price = 300.00M, StartDate = new DateTime(2018, 10, 10, 0, 0, 0), EndDate = new DateTime(2018, 10, 13, 0, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Laughs are on tap for this nationwide tour that promises to hit 300 breweries across the U.S. More than a dozen New York and L.A. stand-ups are currently on the road, sampling the local fare, local brews and providing the finest and funniest in comedy entertainment. This stop at Crucible Brewing Company in Woodinville is set to feature a lineup whose credits include top festivals, TV and major club appearances." },

                new Event() {EventTypeId=10,EventCategoryId=10, Title = "Professional Singles Meetup", OrganizerId = 3, OrganizerName = "Sam Smith", Address= "90 Cherish Avenue", City = "Frederick", State ="Maryland", Zipcode ="21702", Price = 10.00M, StartDate = new DateTime(2018, 9, 23, 12, 0, 0), EndDate = new DateTime(2018, 9, 24, 14, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Get ready for high-flying adventure as the mischievous, forever-young Peter leads Wendy and the Darling children on an unforgettable journey through Never Never Land. A youth cast takes on these magical roles, paying tribute to J.M. Barrie's classic tale as they launch into the musical adaptation's tunes, including I've Gotta Crow and I Won't Grow Up. You'll meet Tinker Bell, the Lost Boys, Captain Hook, a band of pirates and one very hungry crocodile when Peter Pan swoops into Redmond High School Performing Arts Center." },

                new Event() {EventTypeId=7,EventCategoryId=2, Title = "Blockchains's Future in  WallStreet", OrganizerId = 4, OrganizerName = "Mark Harmon", Address= "101 Bull Street", City = "New York City", State ="New York", Zipcode ="10105", Price = 0.00M, StartDate = new DateTime(2018, 9, 29, 11, 0, 0), EndDate = new DateTime(2018, 9, 30, 12, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "One of YouTube's most popular comics, with more than 75 million views and 250,000 subscribers, Steve Hofstetter has appeared on The Late Late Show with Craig Ferguson, ABC's Comics Unleashed, Showtime's White Boyz in the Hood, ESPN and VH1, not to mention making tons of appearances in clubs across the country. Famously known for his epic responses to hecklers, now's your chance to find out what the fuss is about during this no-holds-barred stand-up performance, featuring some of his unfiltered observations about life, at the Parlor Live Comedy Club in Bellevue." },

                new Event() {EventTypeId=1,EventCategoryId=3, Title = "Janet Jackson Live",  OrganizerId = 7, OrganizerName = "John Smith", Address= "Radio City Music Hall", City = "New York City", State ="New York", Zipcode ="10105", Price = 75.5M, StartDate = new DateTime(2018, 11, 10, 7, 10, 0), EndDate = new DateTime(2018, 11, 10, 9, 15, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "DanceSport/Ballroom dance classes for children 5-7 years old from one of US top programs - NIKA International Academy of Ballroom and Latin Dance. Teaching dance all over the world for over 40 years!" },

                new Event() {EventTypeId=6,EventCategoryId=5, Title = "Whales Protection Fund", OrganizerId = 6, OrganizerName = "Cherry Sweet", Address= " 337 Fancy Pants Street", City = "Dallas", State ="Texas", Zipcode ="79231", Price = 1000.0M, StartDate = new DateTime(2018, 11, 16, 20, 30, 0), EndDate = new DateTime(2018, 12, 16, 23, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Tipsy Fox has partnered up with Pizza Coop & Ale House to offer you this Family Night paint event. Recommended age of 7+ to attend but we heavily encourage laughter, singing, dancing, sarcasm and good fun. All kids MUST be accompanied by an adult at all times. Purchase your ticket to reserve your seat and let's get crafty!" },

                new Event() {EventTypeId=7,EventCategoryId=1, Title = "Disney on Ice", OrganizerId = 1, OrganizerName = "John Snow", Address= "MerryWeather Pavilion", City = "Baltimore", State ="Maryland", Zipcode ="21105", Price = 30.0M, StartDate = new DateTime(2018, 12, 25, 12, 0, 0), EndDate = new DateTime(2018, 12, 26, 12, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Tailgate Seattle style…Game Day Husky Boat Cruises are back! Don't worry about fighting traffic, paying the 520 bridge toll or finding expensive parking, instead relax and enjoy a scenic boat ride to and from the game aboard Waterway Cruises' West Star,complete with No Host bar service onboard. On all dates, board at Carillon Point 2 1/2 hours prior to game start time, with sailing departure promptly 2 hours before kick-off. There will be a 1 hour pre-game cruise, and the boat will arrive at Husky Stadium 1 hour before kickoff. The boat will be open for guests throughout the game, the bar will be open during half time, and the boat will depart 30 minutes after the game ends.The boat will return to Carillon Point 1 hour after the game ends. Please continue to check event page for updated kick off times as schedule allows. Tickets for the boat cruise are $80.00 per person including sales tax and one drink voucher (excluding transaction fees). To enjoy waterfront dining before or after your game day excursion, we strongly suggest making your reservation." },

                new Event() {EventTypeId=3,EventCategoryId=4, Title = "Free Wine Tasting ", OrganizerId = 2, OrganizerName = "Mandy Murphy", Address= " 87 Picolo Circle", City = "Bellevue", State ="Washington", Zipcode ="98004", Price = 0.0M, StartDate = new DateTime(2018, 10, 7, 9, 0, 0), EndDate = new DateTime(2018, 10, 8, 17, 30, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate." , EventDescription = "It's hot and what better than getting in the lake. Get signed up for our third and final SAS Wake Day of 2018. Wakeboard and/or wakesurf using 2018 demo gear on Lake Sammamish.Get a few pointers and tips from NW Hyperlite team rider Priscilla Stultz."},

                new Event() {EventTypeId=2,EventCategoryId=3, Title = "Macbeth", OrganizerId = 10, OrganizerName = "Willow Smalls", Address= "12 Stage Avenue", City = "New York City", State ="New York", Zipcode ="11341", Price = 34.99M, StartDate = new DateTime(2018, 10, 23, 20, 0, 0), EndDate = new DateTime(2018, 10, 23, 22, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "The morning begins with an hour long, all levels, Yoga practice. Immediately following our practice we will tour the Copia Farms property, tasting beer, cider, and wine along the way. Leave your worries at the door, get your body in motion, taste some of Seattle's finest craft beverages, and get to know your community." },

                new Event() {EventTypeId=5,EventCategoryId=7, Title = "Surgery in Age of AI", OrganizerId = 2, OrganizerName = "Mandy Murphy", Address= "349 Hospital Blvd", City = "Redmond", State ="Washington", Zipcode ="98118", Price = 0.0M, StartDate = new DateTime(2018, 11, 5, 0, 0, 0), EndDate = new DateTime(2018, 11, 9, 0, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate", EventDescription = "From its home in beautiful Olympia, Washington, Fish Brewing Company has been hand-crafting ales of Northwest proportions since 1993. Founded by Crayne and Mary Horton and a few dozen local investors, Fish began operations humbly. With a 15-barrel brew house and two 15-barrel fermenters, they brewed for their neighbors up and down Puget Sound. Growing steadily since Fish is now an award-winning craft brewer with distribution throughout the great Pacific Northwest and beyond. Today, three distinct brands make their home under Fish Brewing Company's roof: Fish Tale Ales, Spire Mountain Cider, and Leavenworth Biers." },

                new Event() {EventTypeId=10,EventCategoryId=10, Title = "Dallas Job Fair", OrganizerId = 3, OrganizerName = "Sam Smith", Address= "90 Broom Avenue", City = "Dallas", State ="Texas", Zipcode ="78110", Price = 0.00M, StartDate = new DateTime(2018, 10, 10, 12, 0, 0), EndDate = new DateTime(2018, 10, 12, 14, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Love Pilates or maybe just want to try it for the first time?? Grab your bestie and join in in the next Pilates Happy Hour! Fun filled class with friends and then bubbles to celebrate. Questions? Send Jade an email to clear things up!" },

                new Event() {EventTypeId=7,EventCategoryId=2, Title = "Volt Resturant Opening", OrganizerId = 9, OrganizerName = "Mike Manny", Address= "45 Landford Close", City = "Frederick", State ="Maryland", Zipcode ="21764", Price = 10.00M, StartDate = new DateTime(2018, 11, 10, 11, 0, 0), EndDate = new DateTime(2018, 11, 10, 12, 0, 0), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16", OrganizerDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Et molestie ac feugiat sed. Enim sed faucibus turpis in eu mi bibendum neque egestas. Volutpat maecenas volutpat blandit aliquam etiam erat. Sit amet cursus sit amet. Nulla aliquet enim tortor at auctor. Id velit ut tortor pretium viverra. Sit amet nisl purus in. Ac tortor vitae purus faucibus. Egestas quis ipsum suspendisse ultrices gravida. Semper viverra nam libero justo laoreet sit. In massa tempor nec feugiat nisl pretium fusce id. Quam elementum pulvinar etiam non quam lacus. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Egestas integer eget aliquet nibh praesent tristique. Ac tortor vitae purus faucibus ornare suspendisse sed. Fringilla phasellus faucibus scelerisque eleifend donec pretium vulputate.", EventDescription = "Sigma Kappa hosts a 5K run on the beautiful campus of the University of Washington that starts and ends on Memorial Way next to the Burke Museum. All proceeds will be donated to the Alzheimer’s Association."},


            };

        }

    }
}
