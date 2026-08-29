using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Docker.Registry.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Docker.Registry.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class DockerRegistryOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="DockerRegistryOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddDockerRegistryOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IDockerRegistryOpenApiHttpClient, DockerRegistryOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DockerRegistryOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddDockerRegistryOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IDockerRegistryOpenApiHttpClient, DockerRegistryOpenApiHttpClient>();

        return services;
    }
}
