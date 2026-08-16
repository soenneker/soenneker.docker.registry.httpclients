using Soenneker.Docker.Registry.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Docker.Registry.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DockerRegistryOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IDockerRegistryOpenApiHttpClient _httpclient;

    public DockerRegistryOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IDockerRegistryOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
