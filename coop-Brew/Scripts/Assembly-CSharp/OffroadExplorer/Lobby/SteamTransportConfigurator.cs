using Netcode.Transports;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	[RequireComponent(typeof(SteamNetworkingSocketsTransport))]
	public class SteamTransportConfigurator : MonoBehaviour
	{
		[Header("Connection Timeout Settings")]
		[Tooltip("Timeout in milliseconds for established connections (default Steam: ~30000ms). Lower values detect disconnects faster but are more sensitive to lag spikes.")]
		[SerializeField]
		private int timeoutConnectedMs;

		[Tooltip("Timeout in milliseconds for initial connection attempts (default Steam: ~10000ms)")]
		[SerializeField]
		private int timeoutInitialMs;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private SteamNetworkingSocketsTransport steamTransport;

		private void Awake()
		{
		}

		private void ConfigureTransportOptions()
		{
		}

		public void SetTimeoutConnected(int milliseconds)
		{
		}
	}
}
