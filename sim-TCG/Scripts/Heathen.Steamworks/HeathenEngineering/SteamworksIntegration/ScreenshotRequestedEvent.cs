using System;
using Steamworks;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class ScreenshotRequestedEvent : UnityEvent<ScreenshotRequested_t>
	{
	}
}
