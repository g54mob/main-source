using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public class HttpRequestMessageFactory : IHttpRequestFactory<HttpContent>, IDisposable
	{
		private static readonly ReaderWriterLockSlim _httpClientCacheRWLock = new ReaderWriterLockSlim();

		private static readonly IDictionary<string, HttpClientCache> _httpClientCaches = new Dictionary<string, HttpClientCache>();

		private HttpClientCache _httpClientCache;

		private bool _useGlobalHttpClientCache;

		private IClientConfig _clientConfig;

		public HttpRequestMessageFactory(IClientConfig clientConfig)
		{
			_clientConfig = clientConfig;
		}

		public IHttpRequest<HttpContent> CreateHttpRequest(Uri requestUri)
		{
			HttpClient httpClient = null;
			if (ClientConfig.CacheHttpClients(_clientConfig))
			{
				if (_httpClientCache == null)
				{
					if (!ClientConfig.UseGlobalHttpClientCache(_clientConfig))
					{
						_useGlobalHttpClientCache = false;
						_httpClientCacheRWLock.EnterWriteLock();
						try
						{
							if (_httpClientCache == null)
							{
								_httpClientCache = CreateHttpClientCache(_clientConfig);
							}
						}
						finally
						{
							_httpClientCacheRWLock.ExitWriteLock();
						}
					}
					else
					{
						_useGlobalHttpClientCache = true;
						string key = ClientConfig.CreateConfigUniqueString(_clientConfig);
						_httpClientCacheRWLock.EnterReadLock();
						try
						{
							_httpClientCaches.TryGetValue(key, out _httpClientCache);
						}
						finally
						{
							_httpClientCacheRWLock.ExitReadLock();
						}
						if (_httpClientCache == null)
						{
							_httpClientCacheRWLock.EnterWriteLock();
							try
							{
								if (!_httpClientCaches.TryGetValue(key, out _httpClientCache))
								{
									_httpClientCache = CreateHttpClientCache(_clientConfig);
									_httpClientCaches[key] = _httpClientCache;
								}
							}
							finally
							{
								_httpClientCacheRWLock.ExitWriteLock();
							}
						}
					}
				}
				httpClient = _httpClientCache.GetNextClient();
			}
			else
			{
				httpClient = CreateHttpClient(_clientConfig);
			}
			return new HttpWebRequestMessage(httpClient, requestUri, _clientConfig);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_useGlobalHttpClientCache && _httpClientCache != null)
			{
				_httpClientCache.Dispose();
			}
		}

		private static HttpClientCache CreateHttpClientCache(IClientConfig clientConfig)
		{
			HttpClient[] array = new HttpClient[clientConfig.HttpClientCacheSize];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = CreateHttpClient(clientConfig);
			}
			return new HttpClientCache(array);
		}

		private static HttpClient CreateHttpClient(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory == null)
			{
				return CreateManagedHttpClient(clientConfig);
			}
			return clientConfig.HttpClientFactory.CreateHttpClient(clientConfig);
		}

		private static HttpClient CreateManagedHttpClient(IClientConfig clientConfig)
		{
			HttpClientHandler httpClientHandler = new HttpClientHandler();
			if (clientConfig.MaxConnectionsPerServer.HasValue)
			{
				httpClientHandler.MaxConnectionsPerServer = clientConfig.MaxConnectionsPerServer.Value;
			}
			try
			{
				httpClientHandler.AllowAutoRedirect = clientConfig.AllowAutoRedirect;
				httpClientHandler.AutomaticDecompression = DecompressionMethods.None;
			}
			catch (PlatformNotSupportedException exception)
			{
				Logger.GetLogger(typeof(HttpRequestMessageFactory)).Debug(exception, "The current runtime does not support modifying the configuration of HttpClient.");
			}
			try
			{
				IWebProxy webProxy = clientConfig.GetWebProxy();
				if (webProxy != null)
				{
					httpClientHandler.Proxy = webProxy;
				}
				if (httpClientHandler.Proxy != null && clientConfig.ProxyCredentials != null)
				{
					httpClientHandler.Proxy.Credentials = clientConfig.ProxyCredentials;
				}
			}
			catch (PlatformNotSupportedException exception2)
			{
				Logger.GetLogger(typeof(HttpRequestMessageFactory)).Debug(exception2, "The current runtime does not support modifying proxy settings of HttpClient.");
			}
			HttpClient httpClient = new HttpClient(httpClientHandler);
			if (clientConfig.Timeout.HasValue)
			{
				httpClient.Timeout = clientConfig.Timeout.Value;
			}
			return httpClient;
		}
	}
}
