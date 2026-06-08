using System.Net;

namespace Amazon.RuntimeDependencies
{
	public class SSOClientContext
	{
		public RegionEndpoint Region { get; set; }

		public IWebProxy ProxySettings { get; set; }
	}
}
