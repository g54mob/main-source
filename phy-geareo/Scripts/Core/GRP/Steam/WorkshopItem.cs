using Steamworks.Ugc;

namespace GRP.Steam
{
	public class WorkshopItem
	{
		public Steamworks.Ugc.Item item;

		public WorkshopItemMetadata metadata;

		public WorkshopItem(Steamworks.Ugc.Item item)
		{
		}

		public WorkshopItemVisibility GetVisibility()
		{
			return default(WorkshopItemVisibility);
		}
	}
}
