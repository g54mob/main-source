using System;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	[Obsolete("Replaced by WorkshopItem")]
	public class UGCCommunityItem : WorkshopItem
	{
		public UGCCommunityItem(SteamUGCDetails_t itemDetails)
			: base(itemDetails)
		{
		}
	}
}
