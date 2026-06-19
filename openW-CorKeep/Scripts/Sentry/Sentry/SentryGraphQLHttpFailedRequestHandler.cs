using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Protocol;

namespace Sentry
{
	internal class SentryGraphQLHttpFailedRequestHandler : SentryFailedRequestHandler
	{
		private readonly IHub _hub;

		private readonly SentryOptions _options;

		internal const string MechanismType = "GraphqlInstrumentation";

		private readonly SentryHttpFailedRequestHandler _httpFailedRequestHandler;

		internal SentryGraphQLHttpFailedRequestHandler(IHub hub, SentryOptions options)
			: base(hub, options)
		{
			_hub = hub;
			_options = options;
			_httpFailedRequestHandler = new SentryHttpFailedRequestHandler(hub, options);
		}

		protected internal override void DoEnsureSuccessfulResponse([NotNull] HttpRequestMessage request, [NotNull] HttpResponseMessage response)
		{
			JsonElement? jsonElement = null;
			try
			{
				jsonElement = GraphQLContentExtractor.ExtractResponseContentAsync(response, _options).Result;
				if (jsonElement.HasValue && jsonElement.GetValueOrDefault().TryGetProperty("errors", out var value))
				{
					throw new GraphQLHttpRequestException(value[0].GetProperty("message").GetString() ?? "GraphQL Error");
				}
				_httpFailedRequestHandler.DoEnsureSuccessfulResponse(request, response);
			}
			catch (Exception ex)
			{
				ex.SetSentryMechanism("GraphqlInstrumentation", "GraphQL Failed Request Handler", false);
				SentryEvent sentryEvent = new SentryEvent(ex);
				SentryHint hint = new SentryHint("http-response-message", response);
				SentryRequest sentryRequest = new SentryRequest
				{
					QueryString = request.RequestUri?.Query,
					Method = request.Method.Method.ToUpperInvariant(),
					ApiTarget = "graphql"
				};
				Response response2 = new Response
				{
					StatusCode = (short)response.StatusCode,
					BodySize = response.Content?.Headers?.ContentLength
				};
				GraphQLRequestContent fused = request.GetFused<GraphQLRequestContent>();
				if (!_options.SendDefaultPii)
				{
					sentryRequest.Url = request.RequestUri?.HttpRequestUrl();
				}
				else
				{
					sentryRequest.Cookies = request.Headers.GetCookies();
					sentryRequest.Data = fused?.RequestContent;
					sentryRequest.Url = request.RequestUri?.AbsoluteUri;
					sentryRequest.AddHeaders(request.Headers);
					response2.Cookies = response.Headers.GetCookies();
					response2.Data = jsonElement;
					response2.AddHeaders(response.Headers);
				}
				sentryEvent.Request = sentryRequest;
				sentryEvent.Contexts["response"] = response2;
				if (fused != null)
				{
					sentryEvent.Fingerprint = new string[3]
					{
						fused.OperationNameOrFallback(),
						fused.OperationTypeOrFallback(),
						((int)response.StatusCode).ToString()
					};
				}
				base.Hub.CaptureEvent(sentryEvent, null, hint);
			}
		}
	}
}
