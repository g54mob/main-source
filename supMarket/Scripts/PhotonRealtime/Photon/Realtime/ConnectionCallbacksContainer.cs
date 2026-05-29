using System.Collections.Generic;

namespace Photon.Realtime
{
	public class ConnectionCallbacksContainer : List<IConnectionCallbacks>, IConnectionCallbacks
	{
		private readonly LoadBalancingClient client;

		public ConnectionCallbacksContainer(LoadBalancingClient client)
		{
		}

		public void OnConnected()
		{
		}

		public void OnConnectedToMaster()
		{
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
		}

		public void OnDisconnected(DisconnectCause cause)
		{
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
		}
	}
}
