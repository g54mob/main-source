using System;
using Steamworks;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class LobbyEnterEvent : UnityEvent<LobbyEnter_t>
	{
	}
}
