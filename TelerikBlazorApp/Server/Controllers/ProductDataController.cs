using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorApp.Shared;

namespace TelerikBlazorApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductDataController : ControllerBase
    {
        private List<Product> products = ProductViewModel.Getproducts();
        private List<ProductViewModel> buys = new List<ProductViewModel>();
        public ProductDataController()
        {
            Random random = new Random();
            if (buys.Count == 0)
                Enumerable.Range(1, 50).ToList().ForEach(x =>
                {
                    int num = random.Next(0, products.Count);
                    buys.Add(new ProductViewModel()
                    {
                        Name = products[num].Name,
                        Category = products[num].Category,
                        Price = products[num].Price,
                        Date = DateTime.Now.AddDays(-x),
                        Number = random.Next(1, 1500),
                        BuyCount = num * random.Next(1, 50)
                    });
                });
        }
        [HttpGet]
        [Route("AllBuys")]
        public async Task<List<ProductViewModel>> AllBuys()
        {
            return await Task.FromResult(buys);
        }
        [HttpGet]
        [Route("Products")]
        public async Task<List<Product>> AllProducts()
        {
            return await Task.FromResult(products);
        }
        [HttpGet]
        [Route("BuyMaterial")]
        public async Task<int> BuyMaterial()
        {
            return await Task.FromResult(buys.Sum(x => x.BuyCount));
        }
        [HttpGet]
        [Route("GetEarning")]
        public async Task<decimal> GetEarning([FromQuery] bool ByMonth)
        {
            var date = DateTime.Now;
            return await Task.FromResult(buys.Where(x => ByMonth ? x.Date.Month == date.Month : x.Date.Year == date.Year).Sum(x => x.Price));
        }
        [HttpGet]
        [Route("ProductData")]
        public async Task<IEnumerable<ProductViewModel>> ProductData([FromQuery] bool byCategory)
        {
            var CategoryViews = buys.GroupBy(x => byCategory == true ? x.Category : x.Name)
                                .Select(x => new ProductViewModel
                                {
                                    Category = x.Key,
                                    BuyCount = x.Sum(v => v.BuyCount)
                                });

            return await Task.FromResult(CategoryViews);
        }

    }
}
