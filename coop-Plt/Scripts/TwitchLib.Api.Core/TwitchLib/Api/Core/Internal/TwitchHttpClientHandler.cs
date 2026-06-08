using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.Core.Internal
{
	public class TwitchHttpClientHandler : DelegatingHandler
	{
		private readonly ILogger<IHttpCallHandler> _logger;

		public TwitchHttpClientHandler(ILogger<IHttpCallHandler> logger)
			: base(new HttpClientHandler())
		{
			_logger = logger;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request.Content != null)
			{
				ILogger<IHttpCallHandler> logger = _logger;
				if (logger != null)
				{
					ILogger logger2 = logger;
					object obj = DateTime.Now;
					object obj2 = "Request";
					object obj3 = request.Method.ToString();
					object obj4 = request.RequestUri.ToString();
					string text = await request.Content.ReadAsStringAsync();
					logger2.LogInformation("Timestamp: {timestamp} Type: {type} Method: {method} Resource: {url} Content: {content}", obj, obj2, obj3, obj4, text);
				}
			}
			else
			{
				_logger?.LogInformation("Timestamp: {timestamp} Type: {type} Method: {method} Resource: {url}", DateTime.Now, "Request", request.Method.ToString(), request.RequestUri.ToString());
			}
			Stopwatch stopwatch = Stopwatch.StartNew();
			HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
			stopwatch.Stop();
			if (response.IsSuccessStatusCode)
			{
				if (response.Content != null)
				{
					ILogger<IHttpCallHandler> logger3 = _logger;
					if (logger3 != null)
					{
						ILogger logger4 = logger3;
						object obj5 = DateTime.Now;
						object obj6 = "Response";
						object requestUri = response.RequestMessage.RequestUri;
						object obj7 = (int)response.StatusCode;
						object obj8 = stopwatch.ElapsedMilliseconds;
						string text2 = await response.Content.ReadAsStringAsync();
						logger4.LogInformation("Timestamp: {timestamp} Type: {type} Resource: {url} Statuscode: {statuscode} Elapsed: {elapsed} ms Content: {content}", obj5, obj6, requestUri, obj7, obj8, text2);
					}
				}
				else
				{
					_logger?.LogInformation("Timestamp: {timestamp} Type: {type} Resource: {url} Statuscode: {statuscode} Elapsed: {elapsed} ms", DateTime.Now, "Response", response.RequestMessage.RequestUri, (int)response.StatusCode, stopwatch.ElapsedMilliseconds);
				}
			}
			else if (response.Content != null)
			{
				ILogger<IHttpCallHandler> logger5 = _logger;
				if (logger5 != null)
				{
					ILogger logger6 = logger5;
					object obj9 = DateTime.Now;
					object obj10 = "Response";
					object requestUri2 = response.RequestMessage.RequestUri;
					object obj11 = (int)response.StatusCode;
					object obj12 = stopwatch.ElapsedMilliseconds;
					string text3 = await response.Content.ReadAsStringAsync();
					logger6.LogError("Timestamp: {timestamp} Type: {type} Resource: {url} Statuscode: {statuscode} Elapsed: {elapsed} ms Content: {content}", obj9, obj10, requestUri2, obj11, obj12, text3);
				}
			}
			else
			{
				_logger?.LogError("Timestamp: {timestamp} Type: {type} Resource: {url} Statuscode: {statuscode} Elapsed: {elapsed} ms", DateTime.Now, "Response", response.RequestMessage.RequestUri, (int)response.StatusCode, stopwatch.ElapsedMilliseconds);
			}
			return response;
		}
	}
}
