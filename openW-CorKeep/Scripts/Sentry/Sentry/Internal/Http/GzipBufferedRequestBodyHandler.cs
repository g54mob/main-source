using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal.Http
{
	internal class GzipBufferedRequestBodyHandler : DelegatingHandler
	{
		internal class BufferedStreamContent : StreamContent
		{
			internal long ContentLength { get; }

			public BufferedStreamContent(Stream stream, long contentLength, HttpContentHeaders headers)
				: base(stream)
			{
				ContentLength = contentLength;
				foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
				{
					base.Headers.TryAddWithoutValidation(header.Key, header.Value);
				}
				base.Headers.ContentEncoding.Add("gzip");
			}

			protected override bool TryComputeLength(out long length)
			{
				length = ContentLength;
				return true;
			}
		}

		private const string Gzip = "gzip";

		private readonly CompressionLevel _compressionLevel;

		public GzipBufferedRequestBodyHandler(HttpMessageHandler innerHandler, CompressionLevel compressionLevel)
			: base(innerHandler)
		{
			if (compressionLevel == CompressionLevel.NoCompression)
			{
				throw new InvalidOperationException($"Compression mode '{compressionLevel}' is invalid. Avoid registering the handler instead.");
			}
			_compressionLevel = compressionLevel;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (request.Content != null)
			{
				GZipStream gZipStream = new GZipStream(memoryStream, _compressionLevel, leaveOpen: true);
				using (gZipStream)
				{
					await request.Content.CopyToAsync(gZipStream).ConfigureAwait(continueOnCapturedContext: false);
				}
				memoryStream.Position = 0L;
				request.Content = new BufferedStreamContent(memoryStream, memoryStream.Length, request.Content.Headers);
			}
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
