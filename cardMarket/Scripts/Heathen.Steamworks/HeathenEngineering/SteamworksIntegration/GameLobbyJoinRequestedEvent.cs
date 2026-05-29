using System;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class GameLobbyJoinRequestedEvent : UnityEvent<LobbyData, UserData>
	{
	}
}
