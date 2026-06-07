using System.Collections.Generic;
using Brewery.Systems;
using InventorySystem;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public static class CrateBadgeHelper
	{
		public const int MAX_BADGES = 3;

		public const string BADGE_CLASS = "crate-badge";

		public const string BADGES_CONTAINER_CLASS = "crate-badges";

		public const string VISIBLE_CLASS = "visible";

		public static void UpdateBadges(VisualElement badgeContainer, InventorySlot slot, ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public static VisualElement CreateBadgeContainer(string namePrefix, int slotIndex)
		{
			return null;
		}

		private static List<Item> GetUniqueItemsFromCrate(CrateMetadata metadata, int maxCount)
		{
			return null;
		}
	}
}
