using System;
using System.IO.Compression;
using System.Net.Http;
using Sentry.Extensibility;
using Sentry.Http;

namespace Sentry.Internal.Http
{
	internal class DefaultSentryHttpClientFactory : ISentryHttpClientFactory
	{
		public HttpClient Create(SentryOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			HttpMessageHandler httpMessageHandler = options.CreateHttpMessageHandler?.Invoke() ?? new HttpClientHandler();
			if (httpMessageHandler is HttpClientHandler httpClientHandler)
			{
				if (options.HttpProxy != null)
				{
					httpClientHandler.Proxy = options.HttpProxy;
					options.LogInfo("Using Proxy: {0}", options.HttpProxy);
				}
				if (SupportsAutomaticDecompression(httpClientHandler))
				{
					httpClientHandler.AutomaticDecompression = options.DecompressionMethods;
				}
				else
				{
					options.LogWarning("No response compression supported by HttpClientHandler.");
				}
			}
			if (options.RequestBodyCompressionLevel != CompressionLevel.NoCompression)
			{
				if (options.RequestBodyCompressionBuffered)
				{
					httpMessageHandler = new GzipBufferedRequestBodyHandler(httpMessageHandler, options.RequestBodyCompressionLevel);
					options.LogDebug("Using 'GzipBufferedRequestBodyHandler' body compression strategy with level {0}.", options.RequestBodyCompressionLevel);
				}
				else
				{
					httpMessageHandler = new GzipRequestBodyHandler(httpMessageHandler, options.RequestBodyCompressionLevel);
					options.LogDebug("Using 'GzipRequestBodyHandler' body compression strategy with level {0}.", options.RequestBodyCompressionLevel);
				}
			}
			else
			{
				options.LogDebug("Using no request body compression strategy.");
			}
			httpMessageHandler = new RetryAfterHandler(httpMessageHandler);
			HttpClient httpClient = new HttpClient(httpMessageHandler);
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			Action<HttpClient> configureClient = options.ConfigureClient;
			if (configureClient != null)
			{
				options.LogDebug("Invoking user-defined HttpClient configuration action.");
				configureClient(httpClient);
			}
			return httpClient;
		}

		private static bool SupportsAutomaticDecompression(HttpClientHandler handler)
		{
			try
			{
				return handler.SupportsAutomaticDecompression;
			}
			catch (PlatformNotSupportedException)
			{
				return false;
			}
		}
	}
}
