using System;
using Steamworks;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class ActiveBeaconsUpdatedEvent : UnityEvent<ActiveBeaconsUpdated_t>
	{
	}
}
