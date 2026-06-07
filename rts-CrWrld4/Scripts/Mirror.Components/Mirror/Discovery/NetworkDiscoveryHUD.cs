using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Discovery
{
	[DisallowMultipleComponent]
	public class NetworkDiscoveryHUD : MonoBehaviour
	{
		private readonly Dictionary<long, ServerResponse> discoveredServers;

		private Vector2 scrollViewPos;

		public NetworkDiscovery networkDiscovery;

		private void OnGUI()
		{
		}

		private void DrawGUI()
		{
		}

		private void Connect(ServerResponse info)
		{
		}

		public void OnDiscoveredServer(ServerResponse info)
		{
		}
	}
}
