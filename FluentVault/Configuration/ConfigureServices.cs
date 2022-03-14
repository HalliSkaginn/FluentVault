﻿
using FluentVault.Common;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentVault.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddFluentVault(this IServiceCollection services)
    {
        IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        string server = configuration.GetSection($"{nameof(VaultOptions)}:Server").Value;

        return services
                   .Configure<VaultOptions>(configuration.GetSection(nameof(VaultOptions)))
                   .AddHttpClient("Vault", httpClient =>
                       {
                           httpClient.BaseAddress = new Uri($@"http://{server}/");
                       }).Services
                   .AddMediatR(typeof(VaultClient).Assembly)
                   .AddSingleton<IVaultRequestService, VaultRequestService>()
                   .AddTransient<IVaultClient, VaultClient>();
    }
}
