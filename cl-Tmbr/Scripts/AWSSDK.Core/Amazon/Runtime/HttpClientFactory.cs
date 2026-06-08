using System.Net.Http;

namespace Amazon.Runtime
{
	public abstract class HttpClientFactory
	{
		public abstract HttpClient CreateHttpClient(IClientConfig clientConfig);

		public virtual bool UseSDKHttpClientCaching(IClientConfig clientConfig)
		{
			return clientConfig.CacheHttpClient;
		}

		public virtual bool DisposeHttpClientsAfterUse(IClientConfig clientConfig)
		{
			return !UseSDKHttpClientCaching(clientConfig);
		}

		public virtual string GetConfigUniqueString(IClientConfig clientConfig)
		{
			return null;
		}
	}
}
