using System;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class LobbyAuthenticaitonSessionEvent : UnityEvent<AuthenticationSession, byte[]>
	{
	}
}
