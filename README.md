[![](https://img.shields.io/nuget/v/soenneker.docker.registry.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.registry.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.docker.registry.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.docker.registry.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.docker.registry.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.docker.registry.httpclients/)

# Soenneker.Docker.Registry.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Docker.Registry.HttpClients
```

## Quick start

```csharp
using Soenneker.Docker.Registry.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddDockerRegistryOpenApiHttpClientAsSingleton();
```

Adds `DockerRegistryOpenApiHttpClient` as a singleton service.

## What you get

- `IDockerRegistryOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `DockerRegistryOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `DockerRegistryOpenApiHttpClientRegistrar.AddDockerRegistryOpenApiHttpClientAsSingleton(services)` | Adds `DockerRegistryOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `DockerRegistryOpenApiHttpClientRegistrar.AddDockerRegistryOpenApiHttpClientAsScoped(services)` | Adds `DockerRegistryOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
