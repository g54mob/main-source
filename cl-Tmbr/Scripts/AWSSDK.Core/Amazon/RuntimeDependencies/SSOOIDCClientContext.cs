using System.Net;

namespace Amazon.RuntimeDependencies
{
	public class SSOOIDCClientContext
	{
		public RegionEndpoint Region { get; set; }

		public IWebProxy ProxySettings { get; set; }
	}
}
