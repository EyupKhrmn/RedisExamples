using Swashbuckle.AspNetCore.Swagger;

namespace InMemoryCacheRedis;

public static class ServiceRegistiration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ISwaggerProvider>();
        services.AddTransient<IAsyncSwaggerProvider>();
    }
}