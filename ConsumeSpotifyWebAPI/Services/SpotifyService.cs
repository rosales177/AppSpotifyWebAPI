using ConsumeSpotifyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConsumeSpotifyWebAPI.Models.ModelCategories;
using System.Diagnostics;

namespace ConsumeSpotifyWebAPI.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"browse/new-releases?country={countryCode}&limit={limit}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await System.Text.Json.JsonSerializer.DeserializeAsync<GetNewReleaseResult>(responseStream);

            return responseObject?.albums?.items.Select(i => new Release
            {
                Name = i.name,
                Artists = string.Join(",", i.artists.Select(i => i.name)),
                url_image = string.Join(",", i.images.Select(i => i.url)),
                height_img = string.Join(",", i.images.Select(i => i.height).ToString()),
                width_img = string.Join(",", i.images.Select(i => i.width).ToString()),
                url_spotify = i.uri
            });
        }

        public async Task<IEnumerable<ResultCategories>> GetNewCategories(string country, int limit, string locale, int offset, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var responseJson = await _httpClient.GetAsync($"browse/categories?country={country}&limit={limit}&locale={locale}&offset={offset}");

            responseJson.EnsureSuccessStatusCode();

            using var responseStream = await responseJson.Content.ReadAsStreamAsync();
            try
            {
                var JsonToObject = await System.Text.Json.JsonSerializer.DeserializeAsync<GetNewCategories>(responseStream);

                return JsonToObject?.categories?.items.Select(i => new ResultCategories
                {
                    name = i.name,
                    url = string.Join(",",i.icons.Select(i=>i.url))
                    
                });

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<ResultCategories>();
            }

        }

    }
}