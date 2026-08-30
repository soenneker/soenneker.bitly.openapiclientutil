[![](https://img.shields.io/nuget/v/soenneker.bitly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bitly.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bitly.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.bitly.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.bitly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bitly.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bitly.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.bitly.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Bitly.OpenApiClientUtil

Creates and caches an authenticated `BitlyOpenApiClient` for dependency-injected applications.

## Installation

```bash
dotnet add package Soenneker.Bitly.OpenApiClientUtil
```

## Configuration

```json
{
  "Bitly": {
    "ApiKey": "your-access-token"
  }
}
```

`Bitly:ApiKey` is required. The defaults are `https://api-ssl.bitly.com/v4/` and `Authorization: Bearer {token}`. `Bitly:ClientBaseUrl`, `Bitly:AuthHeaderName`, and `Bitly:AuthHeaderValueTemplate` can override them.

## Registration

```csharp
using Soenneker.Bitly.OpenApiClientUtil.Registrars;

services.AddBitlyOpenApiClientUtilAsScoped();
```

The scoped utility uses a singleton HTTP-client provider. Ending a scope disposes the utility's generated client state but leaves the singleton provider and its `HttpClient` alive. Use `AddBitlyOpenApiClientUtilAsSingleton()` when the generated client should also be shared application-wide.

## Usage

```csharp
using Soenneker.Bitly.OpenApiClient;
using Soenneker.Bitly.OpenApiClient.Models;
using Soenneker.Bitly.OpenApiClientUtil.Abstract;

public sealed class BitlyUserService
{
    private readonly IBitlyOpenApiClientUtil _clientUtil;

    public BitlyUserService(IBitlyOpenApiClientUtil clientUtil)
    {
        _clientUtil = clientUtil;
    }

    public async Task<User?> Get(CancellationToken cancellationToken = default)
    {
        BitlyOpenApiClient client = await _clientUtil.Get(cancellationToken);
        return await client.User.GetAsync(cancellationToken: cancellationToken);
    }
}
```

`Get()` lazily creates one generated client per utility instance and returns it afterward. Authentication and base-address configuration are captured during initial creation. Credentials are added only to HTTPS requests and are pinned to the first request host.
