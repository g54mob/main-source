using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public abstract class SentryMessageHandler : DelegatingHandler
	{
		private readonly IHub _hub;

		private readonly SentryOptions? _options;

		private readonly object _innerHandlerLock = new object();

		protected SentryMessageHandler()
			: this(null, null, null)
		{
		}

		protected SentryMessageHandler(HttpMessageHandler innerHandler)
			: this(null, null, innerHandler)
		{
		}

		protected SentryMessageHandler(IHub hub)
			: this(hub, null)
		{
		}

		protected SentryMessageHandler(HttpMessageHandler innerHandler, IHub hub)
			: this(hub, null, innerHandler)
		{
		}

		internal SentryMessageHandler(IHub? hub, SentryOptions? options, HttpMessageHandler? innerHandler = null)
		{
			_hub = hub ?? HubAdapter.Instance;
			_options = options ?? _hub.GetSentryOptions();
			if (innerHandler != null)
			{
				base.InnerHandler = innerHandler;
			}
		}

		protected internal abstract ISpan? ProcessRequest(HttpRequestMessage request, string method, string url);

		protected internal abstract void HandleResponse(HttpResponseMessage response, ISpan? span, string method, string url);

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			string method = request.Method.Method.ToUpperInvariant();
			string url = request.RequestUri?.ToString() ?? string.Empty;
			ISpan span = ProcessRequest(request, method, url);
			try
			{
				PropagateTraceHeaders(request, url);
				HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				HandleResponse(httpResponseMessage, span, method, url);
				return httpResponseMessage;
			}
			catch (Exception exception)
			{
				span?.Finish(exception);
				throw;
			}
		}

		private void PropagateTraceHeaders(HttpRequestMessage request, string url)
		{
			if (base.InnerHandler == null)
			{
				lock (_innerHandlerLock)
				{
					if (base.InnerHandler == null)
					{
						HttpMessageHandler httpMessageHandler = (base.InnerHandler = new HttpClientHandler());
					}
				}
			}
			if ((_options?.TracePropagationTargets.ContainsMatch(url) ?? true) ? true : false)
			{
				AddSentryTraceHeader(request);
				AddBaggageHeader(request);
			}
		}

		private void AddSentryTraceHeader(HttpRequestMessage request)
		{
			if (!request.Headers.Contains("sentry-trace"))
			{
				SentryTraceHeader traceHeader = _hub.GetTraceHeader();
				if (traceHeader != null)
				{
					request.Headers.Add("sentry-trace", traceHeader.ToString());
				}
			}
		}

		private void AddBaggageHeader(HttpRequestMessage request)
		{
			BaggageHeader baggageHeader = _hub.GetBaggage();
			if (baggageHeader == null)
			{
				return;
			}
			if (request.Headers.TryGetValues("baggage", out var values))
			{
				List<string> source = values.ToList();
				if (source.Any((string h) => h.StartsWith("sentry-")))
				{
					return;
				}
				baggageHeader = BaggageHeader.Merge(source.Select((string s) => BaggageHeader.TryParse(s)).ExceptNulls().Append(baggageHeader));
				request.Headers.Remove("baggage");
			}
			request.Headers.Add("baggage", baggageHeader.ToString());
		}
	}
}
