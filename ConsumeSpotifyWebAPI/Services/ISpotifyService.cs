using ConsumeSpotifyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumeSpotifyWebAPI.Models.ModelCategories;

namespace ConsumeSpotifyWebAPI.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken);
        Task<IEnumerable<ResultCategories>> GetNewCategories(string country, int limit, string locale, int offset, string accessToken);
    }
}
