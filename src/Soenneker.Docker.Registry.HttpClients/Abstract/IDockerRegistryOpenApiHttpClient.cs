using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
namespace Soenneker.Docker.Registry.HttpClients.Abstract;
/// <summary>
/// Provides a cached, authenticated HTTP client for the Docker Registry API.
/// </summary>
public interface IDockerRegistryOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured HTTP client used by the Docker Registry OpenAPI HTTP Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
