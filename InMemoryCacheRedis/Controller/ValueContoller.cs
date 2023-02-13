using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCacheRedis.Controller;

public class ValueContoller : BaseController
{
    private readonly IMemoryCache _memoryCache;

    public ValueContoller(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    
    // [HttpGet]
    // public void SetName(string name)
    // {
    //     _memoryCache.Set("name", name, options: new()
    //     {
    //         
    //     });
    // }
    //
    // [HttpPut]
    // public string GetName()
    // {
    //     return _memoryCache.Get<string>("name");
    // }


    [HttpGet]
    public void SetDate()
    {
        _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            SlidingExpiration = TimeSpan.FromSeconds(5)
        });
    }

    
    [HttpPut]
    public DateTime GetDate()
    {
        return _memoryCache.Get<DateTime>("date");
    }
}