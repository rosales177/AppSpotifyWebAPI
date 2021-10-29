using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeSpotifyWebAPI.Models
{
    public class Release
    {
        public string Name { get; set; }
        public string Artists { get; set; }  
        public string url_image { get; set; }
        public string height_img { get; set; }
        public string width_img { get; set; }
        public string url_spotify { get; set; }
    }
}
