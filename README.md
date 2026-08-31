[![](https://img.shields.io/nuget/v/soenneker.docker.registry.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.registry.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.registry.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.docker.registry.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.docker.registry.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.registry.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.registry.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.docker.registry.httpclients/actions/workflows/codeql.yml)

# Soenneker.Docker.Registry.HttpClients

Provides a cached `HttpClient` configured for the Docker Registry API and a supplied bearer token.

## Installation

```bash
dotnet add package Soenneker.Docker.Registry.HttpClients
```

## Configuration

```json
{
  "DockerRegistry": {
    "AccessToken": "your-registry-access-token"
  }
}
```

Keep the token in a secret provider rather than source control.

Optional transport settings use a separate `Registry` section:

```json
{
  "Registry": {
    "ClientBaseUrl": "https://registry-1.docker.io",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

The template replaces every literal `{token}` with `DockerRegistry:AccessToken`. Treat these overrides as trusted configuration because they determine where and how the credential is sent.

## Registration and use

```csharp
using Soenneker.Docker.Registry.HttpClients.Abstract;
using Soenneker.Docker.Registry.HttpClients.Registrars;

services.AddDockerRegistryOpenApiHttpClientAsSingleton();

public sealed class RegistryProbe(IDockerRegistryOpenApiHttpClient clientProvider)
{
    public async Task<HttpResponseMessage> Probe(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.GetAsync("/v2/", cancellationToken);
    }
}
```

`Get` returns the cached client. Do not dispose the returned `HttpClient`; the registered provider owns the cache entry.

Singleton registration is the normal choice for direct transport use. `AddDockerRegistryOpenApiHttpClientAsScoped()` creates a separately owned cache entry for each scope, so disposing one provider cannot remove another provider's client.

This package applies a preconfigured header only. It does not parse `WWW-Authenticate` challenges, exchange Docker credentials for repository-scoped registry tokens, refresh expired tokens, deserialize responses, or translate non-success status codes. Obtain an appropriate registry token before use, or use a higher-level authentication flow around this transport.
