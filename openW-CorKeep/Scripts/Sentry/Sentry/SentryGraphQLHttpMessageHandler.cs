using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Sentry.Extensibility;
using Sentry.Internal;

namespace Sentry
{
	public class SentryGraphQLHttpMessageHandler : SentryMessageHandler
	{
		private readonly IHub _hub;

		private readonly SentryOptions? _options;

		private readonly ISentryFailedRequestHandler? _failedRequestHandler;

		internal const string GraphQlOrigin = "auto.graphql";

		public SentryGraphQLHttpMessageHandler(HttpMessageHandler? innerHandler = null, IHub? hub = null)
			: this(hub, null, innerHandler)
		{
		}

		internal SentryGraphQLHttpMessageHandler(IHub? hub, SentryOptions? options, HttpMessageHandler? innerHandler = null, ISentryFailedRequestHandler? failedRequestHandler = null)
			: base(hub, options, innerHandler)
		{
			_hub = hub ?? HubAdapter.Instance;
			_options = options ?? _hub.GetSentryOptions();
			_failedRequestHandler = failedRequestHandler;
			if (_options != null && _failedRequestHandler == null)
			{
				_failedRequestHandler = new SentryGraphQLHttpFailedRequestHandler(_hub, _options);
			}
		}

		protected internal override ISpan? ProcessRequest(HttpRequestMessage request, string method, string url)
		{
			GraphQLRequestContent result = GraphQLContentExtractor.ExtractRequestContentAsync(request, _options).Result;
			if (result != null)
			{
				GraphQLRequestContent value = result;
				request.SetFused(value);
				ISpan span = _hub.GetSpan()?.StartChild("http.client", method + " " + url);
				span?.SetOrigin("auto.graphql");
				span?.SetExtra("http.request.method", method);
				if (!string.IsNullOrWhiteSpace(request.RequestUri?.Host))
				{
					span?.SetExtra("server.address", request.RequestUri.Host);
				}
				return span;
			}
			_options?.LogDebug("Unable to process non GraphQL request content");
			return null;
		}

		protected internal override void HandleResponse(HttpResponseMessage response, ISpan? span, string method, string url)
		{
			GraphQLRequestContent graphQLRequestContent = response.RequestMessage?.GetFused<GraphQLRequestContent>();
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ "url", url },
				{ "method", method },
				{
					"status_code",
					((int)response.StatusCode).ToString()
				}
			};
			AddIfExists(dictionary, "request_body_size", response.RequestMessage?.Content?.Headers.ContentLength?.ToString());
			AddIfExists(dictionary, "response_body_size", response.Content?.Headers.ContentLength?.ToString());
			AddIfExists(dictionary, "operation_name", graphQLRequestContent?.OperationName);
			AddIfExists(dictionary, "operation_type", graphQLRequestContent?.OperationType);
			_hub.AddBreadcrumb(string.Empty, graphQLRequestContent?.OperationType ?? "graphql.operation", "graphql", dictionary);
			_failedRequestHandler?.HandleResponse(response);
			if (span != null)
			{
				span.SetExtra("http.response.status_code", (int)response.StatusCode);
				span.Description = GetSpanDescriptionOrDefault(graphQLRequestContent, response.StatusCode) ?? span.Description;
				SpanStatus status = SpanStatusConverter.FromHttpStatusCode(response.StatusCode);
				span.Finish(status);
			}
		}

		private string? GetSpanDescriptionOrDefault(GraphQLRequestContent? graphqlInfo, HttpStatusCode statusCode)
		{
			string[] obj = new string[3]
			{
				graphqlInfo?.OperationNameOrFallback(),
				graphqlInfo?.OperationTypeOrFallback(),
				null
			};
			int num = (int)statusCode;
			obj[2] = num.ToString();
			return string.Join(" ", obj);
		}

		private void AddIfExists(Dictionary<string, string> breadcrumbData, string key, string? value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				breadcrumbData[key] = value;
			}
		}
	}
}
