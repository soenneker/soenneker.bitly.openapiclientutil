using Soenneker.Bitly.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Bitly.OpenApiClientUtil.Abstract;

/// <summary>
/// Creates and caches an authenticated <see cref="BitlyOpenApiClient"/>.
/// </summary>
public interface IBitlyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel initial client creation.</param>
    /// <returns>The cached generated client.</returns>
    ValueTask<BitlyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
