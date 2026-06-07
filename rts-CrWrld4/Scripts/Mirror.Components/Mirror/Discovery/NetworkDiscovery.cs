using System.Net;
using UnityEngine;

namespace Mirror.Discovery
{
	[DisallowMultipleComponent]
	public class NetworkDiscovery : NetworkDiscoveryBase<ServerRequest, ServerResponse>
	{
		public Transport transport;

		public ServerFoundUnityEvent OnServerFound;

		public long ServerId { get; private set; }

		public override void Start()
		{
		}

		protected override ServerResponse ProcessRequest(ServerRequest request, IPEndPoint endpoint)
		{
			return default(ServerResponse);
		}

		protected override ServerRequest GetRequest()
		{
			return default(ServerRequest);
		}

		protected override void ProcessResponse(ServerResponse response, IPEndPoint endpoint)
		{
		}
	}
}
