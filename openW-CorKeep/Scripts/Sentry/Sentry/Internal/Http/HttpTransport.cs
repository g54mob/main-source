using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Http;
using Sentry.Infrastructure;
using Sentry.Protocol.Envelopes;

namespace Sentry.Internal.Http
{
	internal class HttpTransport : HttpTransportBase, ITransport
	{
		private readonly HttpClient _httpClient;

		public HttpTransport(SentryOptions options, HttpClient httpClient)
			: base(options)
		{
			_httpClient = httpClient;
		}

		internal HttpTransport(SentryOptions options, HttpClient httpClient, Func<string, string?>? getEnvironmentVariable = null, ISystemClock? clock = null)
			: base(options, getEnvironmentVariable, clock)
		{
			_httpClient = httpClient;
		}

		public virtual async Task SendEnvelopeAsync(Envelope envelope, CancellationToken cancellationToken = default(CancellationToken))
		{
			using Envelope processedEnvelope = ProcessEnvelope(envelope);
			if (processedEnvelope.Items.Count <= 0)
			{
				return;
			}
			using HttpRequestMessage request = CreateRequest(processedEnvelope);
			using HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await HandleResponseAsync(response, processedEnvelope, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
