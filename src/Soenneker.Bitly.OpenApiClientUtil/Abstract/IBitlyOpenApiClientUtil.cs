using Soenneker.Bitly.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Bitly.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IBitlyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<BitlyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
