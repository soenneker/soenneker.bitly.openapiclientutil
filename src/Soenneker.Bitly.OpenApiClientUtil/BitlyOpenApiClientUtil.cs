using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Bitly.HttpClients.Abstract;
using Soenneker.Bitly.OpenApiClientUtil.Abstract;
using Soenneker.Bitly.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Bitly.OpenApiClientUtil;

///<inheritdoc cref="IBitlyOpenApiClientUtil"/>
public sealed class BitlyOpenApiClientUtil : IBitlyOpenApiClientUtil
{
    private readonly AsyncSingleton<BitlyOpenApiClient> _client;

    public BitlyOpenApiClientUtil(IBitlyOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<BitlyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token)
                                                        .NoSync();

            var apiKey = configuration.GetValueStrict<string>("Bitly:ApiKey");
            string authHeaderValueTemplate = configuration["Bitly:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new BitlyOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<BitlyOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}