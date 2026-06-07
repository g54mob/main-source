using System;
using Steamworks;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class SteamRemotePlaySessionConnectedEvent : UnityEvent<SteamRemotePlaySessionConnected_t>
	{
	}
}
