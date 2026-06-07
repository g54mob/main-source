using Brewery.Items;
using InventorySystem;
using UnityEngine;

namespace Brewery.Bar.PhysicalServing
{
	public struct DrinkPoolEntry
	{
		public Item item;

		public BeerDataSnapshot? metadata;

		public float profit;

		public DrinkSource source;

		public ulong sourceOwnerId;

		public int sourceSlotIndex;

		public string DisplayName => null;

		public bool IsValid => false;

		public Sprite Icon => null;

		public string UniqueKey => null;

		public bool Matches(DrinkPoolEntry other)
		{
			return false;
		}

		public static DrinkPoolEntry FromInventorySlot(Item slotItem, BeerDataSnapshot? slotMetadata, DrinkSource source, ulong ownerId, int slotIndex)
		{
			return default(DrinkPoolEntry);
		}
	}
}
