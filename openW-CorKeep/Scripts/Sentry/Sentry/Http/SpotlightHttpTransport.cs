using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Internal.Http;
using Sentry.Protocol.Envelopes;

namespace Sentry.Http
{
	internal class SpotlightHttpTransport : HttpTransport
	{
		private readonly ITransport _inner;

		private readonly SentryOptions _options;

		private readonly HttpClient _httpClient;

		private readonly Uri _spotlightUrl;

		private readonly ISystemClock _clock;

		public SpotlightHttpTransport(ITransport inner, SentryOptions options, HttpClient httpClient, Uri spotlightUrl, ISystemClock clock)
			: base(options, httpClient)
		{
			_options = options;
			_httpClient = httpClient;
			_spotlightUrl = spotlightUrl;
			_inner = inner;
			_clock = clock;
		}

		protected internal override HttpRequestMessage CreateRequest(Envelope envelope)
		{
			HttpRequestMessage obj = new HttpRequestMessage
			{
				RequestUri = _spotlightUrl,
				Method = HttpMethod.Post
			};
			EnvelopeHttpContent envelopeHttpContent = new EnvelopeHttpContent(envelope, _options.DiagnosticLogger, _clock);
			envelopeHttpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-sentry-envelope");
			obj.Content = envelopeHttpContent;
			return obj;
		}

		public override async Task SendEnvelopeAsync(Envelope envelope, CancellationToken cancellationToken = default(CancellationToken))
		{
			Task sentryTask = _inner.SendEnvelopeAsync(envelope, cancellationToken);
			try
			{
				using Envelope processedEnvelope = ProcessEnvelope(envelope);
				if (processedEnvelope.Items.Count > 0)
				{
					using HttpRequestMessage request = CreateRequest(processedEnvelope);
					using HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					await HandleResponseAsync(response, processedEnvelope, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Failed sending envelope to Spotlight.");
			}
			await sentryTask.ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
