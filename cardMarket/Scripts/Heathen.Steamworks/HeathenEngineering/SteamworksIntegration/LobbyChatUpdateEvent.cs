using System;
using Steamworks;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class LobbyChatUpdateEvent : UnityEvent<LobbyChatUpdate_t>
	{
	}
}
