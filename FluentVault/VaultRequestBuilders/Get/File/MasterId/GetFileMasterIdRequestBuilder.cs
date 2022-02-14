﻿namespace FluentVault;

internal class GetFileMasterIdRequestBuilder : IGetFileMasterIdRequestBuilder
{
    private readonly VaultSessionInfo _session;

    public GetFileMasterIdRequestBuilder(VaultSessionInfo session)
    {
        _session = session;
    }

    public async Task<long> ByFilename(string filename)
    {
        var file = await new SearchFilesRequestBuilder(_session).ByFilename(filename);
        return file.MasterId;
    }
}
