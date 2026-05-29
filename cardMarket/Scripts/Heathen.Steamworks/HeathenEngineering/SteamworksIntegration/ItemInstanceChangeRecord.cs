using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct ItemInstanceChangeRecord
	{
		public SteamItemInstanceID_t instance;

		public bool added;

		public bool removed;

		public bool changed;

		public int quantityBefore;

		public int quantityAfter;

		public int QuantityChange => quantityAfter - quantityBefore;
	}
}
