﻿using System.Net.Http;

using FluentVault.Common;

using Microsoft.Extensions.Options;

namespace FluentVault.IntegrationTests.Fixtures;
internal class VaultRequestServiceFixture
{
    public VaultRequestServiceFixture()
    {
        IOptions<VaultOptions> options = new VaultOptionsFixture().Create();
        IHttpClientFactory factory = new VaultHttpClientFactory();
        VaultRequestService = new VaultService(factory, options);
    }

    public IVaultService VaultRequestService { get; }
}
