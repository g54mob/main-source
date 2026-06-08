using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public class HttpWebRequestMessage : IHttpRequest<HttpContent>, IDisposable
	{
		private static HashSet<string> ContentHeaderNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Content-Length", "Content-Type", "Content-Range", "Content-MD5", "Content-Encoding", "Content-Disposition", "Expires" };

		private bool _disposed;

		private HttpRequestMessage _request;

		private HttpClient _httpClient;

		private IClientConfig _clientConfig;

		public HttpClient HttpClient => _httpClient;

		public HttpRequestMessage Request => _request;

		public string Method
		{
			get
			{
				return _request.Method.Method;
			}
			set
			{
				_request.Method = new HttpMethod(value);
			}
		}

		public Uri RequestUri => _request.RequestUri;

		public Version HttpProtocolVersion
		{
			get
			{
				return _request.Version;
			}
			set
			{
				_request.Version = value;
			}
		}

		public HttpWebRequestMessage(HttpClient httpClient, Uri requestUri, IClientConfig config)
		{
			_clientConfig = config;
			_httpClient = httpClient;
			_request = new HttpRequestMessage();
			_request.RequestUri = requestUri;
		}

		public void ConfigureRequest(IRequestContext requestContext)
		{
			if (requestContext != null && requestContext.OriginalRequest != null)
			{
				_request.Headers.ExpectContinue = requestContext.OriginalRequest.GetExpect100Continue();
			}
		}

		public void SetRequestHeaders(IDictionary<string, string> headers)
		{
			foreach (KeyValuePair<string, string> header in headers)
			{
				if (!ContentHeaderNames.Contains(header.Key))
				{
					_request.Headers.TryAddWithoutValidation(header.Key, header.Value);
				}
			}
		}

		public HttpContent GetRequestContent()
		{
			return _request.Content;
		}

		public IWebResponseData GetResponse()
		{
			try
			{
				return GetResponseAsync(CancellationToken.None).Result;
			}
			catch (AggregateException ex)
			{
				throw ex.InnerException;
			}
		}

		public void Abort()
		{
		}

		public async Task<IWebResponseData> GetResponseAsync(CancellationToken cancellationToken)
		{
			try
			{
				return ProcessHttpResponseMessage(await _httpClient.SendAsync(_request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
			}
			catch (HttpRequestException ex)
			{
				if (ex.InnerException != null && ex.InnerException is IOException)
				{
					throw ex.InnerException;
				}
				throw;
			}
			catch (OperationCanceledException ex2)
			{
				if (!cancellationToken.IsCancellationRequested && ex2.InnerException != null)
				{
					throw ex2.InnerException;
				}
				throw;
			}
		}

		private HttpClientResponseData ProcessHttpResponseMessage(HttpResponseMessage responseMessage)
		{
			bool disposeClient = ClientConfig.DisposeHttpClients(_clientConfig);
			if (!_clientConfig.AllowAutoRedirect && responseMessage.StatusCode >= HttpStatusCode.MultipleChoices && responseMessage.StatusCode < HttpStatusCode.BadRequest)
			{
				return new HttpClientResponseData(responseMessage, _httpClient, disposeClient);
			}
			if (!responseMessage.IsSuccessStatusCode)
			{
				throw new HttpErrorResponseException(new HttpClientResponseData(responseMessage, _httpClient, disposeClient));
			}
			return new HttpClientResponseData(responseMessage, _httpClient, disposeClient);
		}

		public void WriteToRequestBody(HttpContent requestContent, Stream contentStream, IDictionary<string, string> contentHeaders, IRequestContext requestContext)
		{
			NonDisposingWrapperStream content = new NonDisposingWrapperStream(contentStream);
			_request.Content = new StreamContent(content, requestContext.ClientConfig.BufferSize);
			ChunkedUploadWrapperStream chunkedUploadWrapperStream = contentStream as ChunkedUploadWrapperStream;
			TrailingHeadersWrapperStream trailingHeadersWrapperStream = contentStream as TrailingHeadersWrapperStream;
			CompressionWrapperStream compressionWrapperStream = contentStream as CompressionWrapperStream;
			bool num = chunkedUploadWrapperStream?.HasLength ?? false;
			bool flag = trailingHeadersWrapperStream?.HasLength ?? false;
			bool flag2 = compressionWrapperStream?.HasLength ?? false;
			if (num || flag || flag2 || (chunkedUploadWrapperStream == null && trailingHeadersWrapperStream == null && compressionWrapperStream == null))
			{
				long num2;
				try
				{
					num2 = contentStream.Position;
				}
				catch (NotSupportedException)
				{
					num2 = 0L;
				}
				_request.Content.Headers.ContentLength = contentStream.Length - num2;
			}
			WriteContentHeaders(contentHeaders);
		}

		public IHttpRequestStreamHandle SetupHttpRequestStreamPublisher(IDictionary<string, string> contentHeaders, IHttpRequestStreamPublisher requestStreamPublisher)
		{
			throw new NotImplementedException();
		}

		public void WriteToRequestBody(HttpContent requestContent, byte[] content, IDictionary<string, string> contentHeaders)
		{
			_request.Content = new ByteArrayContent(content);
			_request.Content.Headers.ContentLength = content.Length;
			WriteContentHeaders(contentHeaders);
		}

		public Task<HttpContent> GetRequestContentAsync()
		{
			return Task.FromResult(_request.Content);
		}

		private void WriteContentHeaders(IDictionary<string, string> contentHeaders)
		{
			if (contentHeaders.ContainsKey("Content-Type"))
			{
				_request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentHeaders["Content-Type"]);
			}
			if (contentHeaders.TryGetValue("Content-Range", out var value))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-Range", value);
			}
			if (contentHeaders.TryGetValue("Content-MD5", out var value2))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-MD5", value2);
			}
			if (contentHeaders.TryGetValue("Content-Encoding", out var value3))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-Encoding", value3);
			}
			if (contentHeaders.TryGetValue("Content-Disposition", out var value4))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-Disposition", value4);
			}
			if (contentHeaders.TryGetValue("Expires", out var value5) && DateTime.TryParse(value5, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
			{
				_request.Content.Headers.Expires = result;
			}
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
				if (_request != null)
				{
					_request.Dispose();
				}
				_disposed = true;
			}
		}

		public Stream SetupProgressListeners(Stream originalStream, long progressUpdateInterval, object sender, EventHandler<StreamTransferProgressArgs> callback)
		{
			EventStream eventStream = new EventStream(originalStream, disableClose: true);
			StreamReadTracker streamReadTracker = new StreamReadTracker(sender, callback, originalStream.Length, progressUpdateInterval);
			eventStream.OnRead += streamReadTracker.ReadProgress;
			return eventStream;
		}
	}
}
