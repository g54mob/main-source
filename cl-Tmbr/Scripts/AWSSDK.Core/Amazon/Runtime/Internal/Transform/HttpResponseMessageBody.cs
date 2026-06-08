using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Transform
{
	public class HttpResponseMessageBody : IHttpResponseBody, IDisposable
	{
		private HttpClient _httpClient;

		private HttpResponseMessage _response;

		private bool _disposeClient;

		private bool _disposed;

		public HttpResponseMessageBody(HttpResponseMessage response, HttpClient httpClient, bool disposeClient)
		{
			_httpClient = httpClient;
			_response = response;
			_disposeClient = disposeClient;
		}

		public Stream OpenResponse()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("HttpWebResponseBody");
			}
			return _response.Content.ReadAsStreamAsync().Result;
		}

		public Task<Stream> OpenResponseAsync()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("HttpWebResponseBody");
			}
			return _response.Content.ReadAsStreamAsync();
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				if (_response != null)
				{
					_response.Dispose();
				}
				if (_httpClient != null && _disposeClient)
				{
					_httpClient.Dispose();
				}
				_disposed = true;
			}
		}
	}
}
