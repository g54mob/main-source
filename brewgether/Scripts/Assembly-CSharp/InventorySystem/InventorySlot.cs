using System;
using System.Collections.Generic;
using Brewery.Items;
using Brewery.Systems;

namespace InventorySystem
{
	[Serializable]
	public class InventorySlot
	{
		public Item item;

		public int quantity;

		public BeerDataSnapshot? beverageMetadata;

		public BarrelMetadata? barrelMetadata;

		public CrateMetadata? crateMetadata;

		public GarbageMetadata? garbageMetadata;

		public Dictionary<int, BeerDataSnapshot> crateItemBeverageMetadata;

		public Dictionary<int, BarrelMetadata> crateItemBarrelMetadata;

		public bool IsEmpty => false;

		public bool HasBeverageMetadata => false;

		public bool HasBarrelMetadata => false;

		public bool HasCrateMetadata => false;

		public bool HasGarbageMetadata => false;

		public bool HasCrateItemMetadata => false;

		public InventorySlot()
		{
		}

		public InventorySlot(Item newItem, int newQuantity, BeerDataSnapshot? metadata = null)
		{
		}

		public void AddQuantity(int amount)
		{
		}

		public void RemoveQuantity(int amount)
		{
		}

		public void SetItem(Item newItem, int newQuantity, BeerDataSnapshot? metadata = null)
		{
		}

		public void SetBarrelItem(Item newItem, int newQuantity, BarrelMetadata? metadata)
		{
		}

		public void SetCrateItem(Item newItem, int newQuantity, CrateMetadata? contents, Dictionary<int, BeerDataSnapshot> itemBeverages = null, Dictionary<int, BarrelMetadata> itemBarrels = null)
		{
		}

		public void Clear()
		{
		}

		public bool CanStackWith(Item otherItem)
		{
			return false;
		}

		public int GetRemainingStackSpace(int? overrideMaxStack = null)
		{
			return 0;
		}

		public InventorySlot Clone()
		{
			return null;
		}

		public void SetBeverageMetadata(BeerDataSnapshot metadata)
		{
		}

		public void ClearBeverageMetadata()
		{
		}

		public void SetBarrelMetadata(BarrelMetadata metadata)
		{
		}

		public void ClearBarrelMetadata()
		{
		}

		public void SetCrateMetadata(CrateMetadata metadata)
		{
		}

		public void ClearCrateMetadata()
		{
		}

		public GarbageMetadata GetGarbageMetadata()
		{
			return default(GarbageMetadata);
		}

		public void SetGarbageMetadata(GarbageMetadata metadata)
		{
		}

		public void ClearGarbageMetadata()
		{
		}

		public void SetCrateItemBeverageMetadata(int crateSlot, BeerDataSnapshot metadata)
		{
		}

		public void SetCrateItemBarrelMetadata(int crateSlot, BarrelMetadata metadata)
		{
		}

		public bool TryGetCrateItemBeverageMetadata(int crateSlot, out BeerDataSnapshot metadata)
		{
			metadata = default(BeerDataSnapshot);
			return false;
		}

		public bool TryGetCrateItemBarrelMetadata(int crateSlot, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public void RemoveCrateItemBeverageMetadata(int crateSlot)
		{
		}

		public void RemoveCrateItemBarrelMetadata(int crateSlot)
		{
		}

		public string GetDisplayName()
		{
			return null;
		}

		public void CopyMetadataFrom(InventorySlot source)
		{
		}
	}
}
