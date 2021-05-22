using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TelerikBlazorApp.Shared;

namespace TelerikBlazorApp.Client.Services
{
    public class DashboardService : IDashboardService
    {
        private HttpClient _httpclient { set; get; }
        public DashboardService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }
        public Task<List<ProductViewModel>> AllBuys()
        {
            return  _httpclient.GetFromJsonAsync<List<ProductViewModel>>("ProductData/AllBuys");
        }

        public Task<List<Product>> AllProducts()
        {
            return _httpclient.GetFromJsonAsync<List<Product>>("ProductData/AllProducts");

        }

        public Task<int> BuyMaterial()
        {
            return _httpclient.GetFromJsonAsync<int>("ProductData/BuyMaterial");

        }

        public Task<decimal> GetEarning(bool ByMonth)
        {
            return _httpclient.GetFromJsonAsync<decimal>("ProductData/GetEarning?ByMonth="+ByMonth);

        }

        public async Task<IEnumerable<ProductViewModel>> ProductData(bool byCategory)
        {
            return await _httpclient.GetFromJsonAsync<IEnumerable<ProductViewModel>>("ProductData/ProductData?byCategory=" + byCategory);
        }
    }
}
