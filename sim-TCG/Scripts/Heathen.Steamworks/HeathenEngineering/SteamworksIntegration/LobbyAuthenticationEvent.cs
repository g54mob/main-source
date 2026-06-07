using System;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class LobbyAuthenticationEvent : UnityEvent<LobbyData, UserData, byte[], byte[]>
	{
	}
}
