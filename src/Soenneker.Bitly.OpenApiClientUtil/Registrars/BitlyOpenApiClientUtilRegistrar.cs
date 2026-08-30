using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Bitly.HttpClients.Registrars;
using Soenneker.Bitly.OpenApiClientUtil.Abstract;

namespace Soenneker.Bitly.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class BitlyOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IBitlyOpenApiClientUtil"/> as a singleton service backed by the singleton HTTP-client provider.
    /// </summary>
    public static IServiceCollection AddBitlyOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBitlyOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IBitlyOpenApiClientUtil, BitlyOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IBitlyOpenApiClientUtil"/> as a scoped service backed by the singleton HTTP-client provider.
    /// </summary>
    public static IServiceCollection AddBitlyOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddBitlyOpenApiHttpClientAsSingleton()
                .TryAddScoped<IBitlyOpenApiClientUtil, BitlyOpenApiClientUtil>();

        return services;
    }
}
