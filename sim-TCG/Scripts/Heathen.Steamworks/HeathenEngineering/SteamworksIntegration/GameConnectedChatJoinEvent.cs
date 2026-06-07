using System;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class GameConnectedChatJoinEvent : UnityEvent<ChatRoom, UserData>
	{
	}
}
