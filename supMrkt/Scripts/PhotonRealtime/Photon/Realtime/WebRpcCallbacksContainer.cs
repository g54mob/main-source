using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	internal class WebRpcCallbacksContainer : List<IWebRpcCallback>, IWebRpcCallback
	{
		private LoadBalancingClient client;

		public WebRpcCallbacksContainer(LoadBalancingClient client)
		{
		}

		public void OnWebRpcResponse(OperationResponse response)
		{
		}
	}
}
