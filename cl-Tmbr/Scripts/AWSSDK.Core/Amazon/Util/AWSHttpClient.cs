using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amazon.Util
{
	public class AWSHttpClient : IDisposable
	{
		private HttpClient _httpClient;

		private bool disposed;

		public Uri BaseAddress
		{
			get
			{
				return _httpClient.BaseAddress;
			}
			set
			{
				_httpClient.BaseAddress = value;
			}
		}

		public TimeSpan Timeout
		{
			get
			{
				return _httpClient.Timeout;
			}
			set
			{
				_httpClient.Timeout = value;
			}
		}

		public long MaxResponseContentBufferSize
		{
			get
			{
				return _httpClient.MaxResponseContentBufferSize;
			}
			set
			{
				_httpClient.MaxResponseContentBufferSize = value;
			}
		}

		public AWSHttpClient()
		{
			_httpClient = new HttpClient();
		}

		internal AWSHttpClient(IWebProxy proxy, bool useProxy)
		{
			_httpClient = new HttpClient(new HttpClientHandler
			{
				Proxy = proxy,
				UseProxy = useProxy
			});
		}

		internal AWSHttpClient(HttpMessageHandler handler)
		{
			_httpClient = new HttpClient(handler);
		}

		internal AWSHttpClient(HttpMessageHandler handler, bool disposeHandler)
		{
			_httpClient = new HttpClient(handler, disposeHandler);
		}

		public Task<Stream> GetStreamAsync(string requestUri)
		{
			return _httpClient.GetStreamAsync(requestUri);
		}

		public Task PutRequestUriAsync(string requestUri, AWSStreamContent content, IDictionary<string, string> requestHeaders)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri);
			httpRequestMessage.Content = content.StreamContent;
			foreach (KeyValuePair<string, string> requestHeader in requestHeaders)
			{
				httpRequestMessage.Headers.TryAddWithoutValidation(requestHeader.Key, requestHeader.Value);
			}
			return _httpClient.SendAsync(httpRequestMessage);
		}

		public async Task<List<Tuple<string, IEnumerable<string>, HttpStatusCode>>> GetResponseHeadersAsync(string httpMethodValue, string url)
		{
			HttpMethod method = new HttpMethod(httpMethodValue);
			List<Tuple<string, IEnumerable<string>, HttpStatusCode>> headers = new List<Tuple<string, IEnumerable<string>, HttpStatusCode>>();
			HttpRequestMessage request = new HttpRequestMessage(method, url);
			HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			foreach (KeyValuePair<string, IEnumerable<string>> header in httpResponseMessage.Headers)
			{
				headers.Add(new Tuple<string, IEnumerable<string>, HttpStatusCode>(header.Key, header.Value, httpResponseMessage.StatusCode));
			}
			return headers;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_httpClient.Dispose();
				}
				disposed = true;
			}
		}

		public static bool IsHttpInnerException(Exception exception)
		{
			return exception is HttpRequestException;
		}
	}
}
