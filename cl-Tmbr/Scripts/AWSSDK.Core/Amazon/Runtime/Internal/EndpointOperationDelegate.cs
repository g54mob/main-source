using System.Collections.Generic;

namespace Amazon.Runtime.Internal
{
	public delegate IEnumerable<DiscoveryEndpointBase> EndpointOperationDelegate(EndpointOperationContextBase context);
}
