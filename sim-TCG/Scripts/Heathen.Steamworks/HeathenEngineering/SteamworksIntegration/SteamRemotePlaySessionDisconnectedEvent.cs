using System;
using Steamworks;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class SteamRemotePlaySessionDisconnectedEvent : UnityEvent<SteamRemotePlaySessionDisconnected_t>
	{
	}
}
