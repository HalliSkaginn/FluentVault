﻿using System.Xml.Linq;

using FluentVault.Common.Helpers;

namespace FluentVault.Requests;

internal abstract class SessionRequest : BaseRequest
{
    protected SessionRequest(VaultSession session, RequestData requestData)
        : base(requestData) => Session = session;

    public VaultSession Session { get; }

    public async Task<XDocument> SendAsync(string requestBody)
    {
        Uri uri = RequestData.GetUri(Session.Server);
        XDocument document = await SendAsync(uri, requestBody);

        return document;
    }
}
