using System.Collections.Generic;
using System.Net.Http;
using Sentry.Extensibility;
using Sentry.Internal;

namespace Sentry
{
	public class SentryHttpMessageHandler : SentryMessageHandler
	{
		private readonly IHub _hub;

		private readonly SentryOptions? _options;

		private readonly ISentryFailedRequestHandler? _failedRequestHandler;

		internal const string HttpClientOrigin = "auto.http.client";

		public SentryHttpMessageHandler()
			: this(null, null, null, null)
		{
		}

		public SentryHttpMessageHandler(HttpMessageHandler innerHandler)
			: this(null, null, innerHandler)
		{
		}

		public SentryHttpMessageHandler(IHub hub)
			: this(hub, null)
		{
		}

		public SentryHttpMessageHandler(HttpMessageHandler innerHandler, IHub hub)
			: this(hub, null, innerHandler)
		{
		}

		internal SentryHttpMessageHandler(IHub? hub, SentryOptions? options, HttpMessageHandler? innerHandler = null, ISentryFailedRequestHandler? failedRequestHandler = null)
			: base(hub, options, innerHandler)
		{
			_hub = hub ?? HubAdapter.Instance;
			_options = options ?? _hub.GetSentryOptions();
			_failedRequestHandler = failedRequestHandler;
			if (_failedRequestHandler == null && _options != null)
			{
				_failedRequestHandler = new SentryHttpFailedRequestHandler(_hub, _options);
			}
		}

		protected internal override ISpan? ProcessRequest(HttpRequestMessage request, string method, string url)
		{
			ISpan span = _hub.GetSpan()?.StartChild("http.client", method + " " + url);
			span?.SetOrigin("auto.http.client");
			span?.SetExtra("http.request.method", method);
			if ((object)request.RequestUri != null && !string.IsNullOrWhiteSpace(request.RequestUri.Host))
			{
				span?.SetExtra("server.address", request.RequestUri.Host);
			}
			return span;
		}

		protected internal override void HandleResponse(HttpResponseMessage response, ISpan? span, string method, string url)
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				{ "url", url },
				{ "method", method },
				{
					"status_code",
					((int)response.StatusCode).ToString()
				}
			};
			_hub.AddBreadcrumb(string.Empty, "http", "http", data);
			_failedRequestHandler?.HandleResponse(response);
			if (span != null)
			{
				span.SetExtra("http.response.status_code", (int)response.StatusCode);
				SpanStatus status = SpanStatusConverter.FromHttpStatusCode(response.StatusCode);
				span.Finish(status);
			}
		}
	}
}
