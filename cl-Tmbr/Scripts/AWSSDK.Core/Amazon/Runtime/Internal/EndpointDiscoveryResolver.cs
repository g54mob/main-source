using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public class EndpointDiscoveryResolver : EndpointDiscoveryResolverBase
	{
		public EndpointDiscoveryResolver(IClientConfig config, Logger logger)
			: base(config, logger)
		{
		}
	}
}
