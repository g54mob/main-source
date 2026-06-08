using System;

namespace Amazon.Runtime.Internal
{
	public class EndpointOperationContext : EndpointOperationContextBase
	{
		public EndpointOperationContext(string customerCredentials, string operationName, EndpointDiscoveryDataBase endpointDiscoveryData, bool evictCacheKey, Uri evictUri)
			: base(customerCredentials, operationName, endpointDiscoveryData, evictCacheKey, evictUri)
		{
		}
	}
}
