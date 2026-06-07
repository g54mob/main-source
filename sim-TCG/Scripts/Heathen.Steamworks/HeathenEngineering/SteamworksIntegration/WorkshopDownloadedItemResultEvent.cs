using System;
using Steamworks;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public class WorkshopDownloadedItemResultEvent : UnityEvent<DownloadItemResult_t>
	{
	}
}
