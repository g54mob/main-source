using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal.Http
{
	internal class GzipRequestBodyHandler : DelegatingHandler
	{
		internal class GzipContent : HttpContent
		{
			private readonly HttpContent _content;

			private readonly CompressionLevel _compressionLevel;

			public GzipContent(HttpContent content, CompressionLevel compressionLevel)
			{
				_content = content;
				_compressionLevel = compressionLevel;
				foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
				{
					base.Headers.TryAddWithoutValidation(header.Key, header.Value);
				}
				base.Headers.ContentEncoding.Add("gzip");
			}

			protected override bool TryComputeLength(out long length)
			{
				length = -1L;
				return false;
			}

			protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
			{
				GZipStream gZipStream = new GZipStream(stream, _compressionLevel, leaveOpen: true);
				using (gZipStream)
				{
					await _content.CopyToAsync(gZipStream).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}

		private const string Gzip = "gzip";

		private readonly CompressionLevel _compressionLevel;

		public GzipRequestBodyHandler(HttpMessageHandler innerHandler, CompressionLevel compressionLevel)
			: base(innerHandler)
		{
			if (compressionLevel == CompressionLevel.NoCompression)
			{
				throw new InvalidOperationException($"Compression mode '{compressionLevel}' is invalid. Avoid registering the handler instead.");
			}
			_compressionLevel = compressionLevel;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request.Content != null)
			{
				request.Content = new GzipContent(request.Content, _compressionLevel);
			}
			return base.SendAsync(request, cancellationToken);
		}
	}
}
