using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using Sentry.Internal.Extensions;
using Sentry.Protocol;

namespace Sentry
{
	internal class SentryHttpFailedRequestHandler : SentryFailedRequestHandler
	{
		public const string MechanismType = "SentryHttpFailedRequestHandler";

		internal SentryHttpFailedRequestHandler(IHub hub, SentryOptions options)
			: base(hub, options)
		{
		}

		protected internal override void DoEnsureSuccessfulResponse([NotNull] HttpRequestMessage request, [NotNull] HttpResponseMessage response)
		{
			if (!base.Options.FailedRequestStatusCodes.Any((HttpStatusCodeRange range) => range.Contains(response.StatusCode)))
			{
				return;
			}
			try
			{
				response.StatusCode.EnsureSuccessStatusCode();
			}
			catch (HttpRequestException ex)
			{
				ex.SetSentryMechanism("SentryHttpFailedRequestHandler");
				SentryEvent sentryEvent = new SentryEvent(ex);
				SentryHint hint = new SentryHint("http-response-message", response);
				Uri uri = response.RequestMessage?.RequestUri;
				SentryRequest sentryRequest = new SentryRequest
				{
					QueryString = uri?.Query,
					Method = response.RequestMessage?.Method.Method.ToUpperInvariant()
				};
				Response response2 = new Response
				{
					StatusCode = (short)response.StatusCode,
					BodySize = response.Content?.Headers?.ContentLength
				};
				if (!base.Options.SendDefaultPii)
				{
					sentryRequest.Url = uri?.HttpRequestUrl();
				}
				else
				{
					sentryRequest.Url = uri?.AbsoluteUri;
					sentryRequest.Cookies = request.Headers.GetCookies();
					sentryRequest.AddHeaders(request.Headers);
					response2.Cookies = response.Headers.GetCookies();
					response2.AddHeaders(response.Headers);
				}
				sentryEvent.Request = sentryRequest;
				sentryEvent.Contexts["response"] = response2;
				base.Hub.CaptureEvent(sentryEvent, null, hint);
			}
		}
	}
}
