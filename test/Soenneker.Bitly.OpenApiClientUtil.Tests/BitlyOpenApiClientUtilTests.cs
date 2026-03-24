using Soenneker.Bitly.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Bitly.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class BitlyOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IBitlyOpenApiClientUtil _openapiclientutil;

    public BitlyOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IBitlyOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
