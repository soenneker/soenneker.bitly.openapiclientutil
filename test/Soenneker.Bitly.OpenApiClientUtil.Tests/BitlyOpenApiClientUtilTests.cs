using Soenneker.Bitly.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Bitly.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BitlyOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IBitlyOpenApiClientUtil _openapiclientutil;

    public BitlyOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IBitlyOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
