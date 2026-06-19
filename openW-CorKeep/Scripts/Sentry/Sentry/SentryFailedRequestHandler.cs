using System;
using System.Net.Http;

namespace Sentry
{
	internal abstract class SentryFailedRequestHandler : ISentryFailedRequestHandler
	{
		protected IHub Hub { get; }

		protected SentryOptions Options { get; }

		internal SentryFailedRequestHandler(IHub hub, SentryOptions options)
		{
			Hub = hub;
			Options = options;
		}

		protected internal abstract void DoEnsureSuccessfulResponse(HttpRequestMessage request, HttpResponseMessage response);

		public void HandleResponse(HttpResponseMessage response)
		{
			if (response.RequestMessage == null || !Options.CaptureFailedRequests)
			{
				return;
			}
			Uri requestUri = response.RequestMessage.RequestUri;
			if (requestUri != null)
			{
				string dsn = Options.Dsn;
				if (dsn != null && new Uri(dsn).Host.Equals(requestUri.Host, StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
				string str = requestUri.ToString();
				if (!Options.FailedRequestTargets.ContainsMatch(str))
				{
					return;
				}
			}
			DoEnsureSuccessfulResponse(response.RequestMessage, response);
		}
	}
}
