using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorApp.Shared;

namespace TelerikBlazorApp.Client.Services
{
    interface IDashboardService
    {
        Task<List<ProductViewModel>> AllBuys();
        Task<List<Product>> AllProducts();
        Task<int> BuyMaterial();
        Task<decimal> GetEarning(bool ByMonth);
        Task<IEnumerable<ProductViewModel>> ProductData(bool ByCategory);
    }
}
