using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct InventoryResult
	{
		public ItemDetail[] items;

		public EResult result;

		public DateTime timestamp;
	}
}
