using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeSpotifyWebAPI.Models.ModelCategories
{
    public class GetNewCategories
    {
        public Category categories { get; set; }
    }
    public class Category
    { 
        public string href { get; set; }
        public Items[] items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public string previous { get; set; }
        public int total { get; set; }
    }
    public class Items
    { 
        public string href { get; set; }
        public Icons[] icons { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class Icons
    {
        public string url { get; set; }
        //public int height { get; set; }
        //public int width { get; set; }

    }
}
