namespace Amazon.Runtime.Internal
{
	public class DiscoveryEndpoint : DiscoveryEndpointBase
	{
		public DiscoveryEndpoint(string address, long cachePeriodInMinutes)
			: base(address, cachePeriodInMinutes)
		{
		}
	}
}
