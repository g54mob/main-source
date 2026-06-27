using UnityEngine;

namespace Restory.StorageSystem
{
	public static class IStorageEx
	{
		public static int AddItem(this IStorage storage, int index, IStorageItem item, int quantity = 1)
		{
			IReadOnlyStorageSlot readOnlyStorageSlot = storage[index];
			if (readOnlyStorageSlot.IsEmpty())
			{
				return storage.SetItem(index, item, quantity);
			}
			if (!(item is IStorageItemStackable item2) || !(readOnlyStorageSlot.Item is IStorageItemStackable storageItemStackable))
			{
				return quantity;
			}
			if (!storageItemStackable.CanStackWith(item2))
			{
				return quantity;
			}
			int num = Mathf.Min(storageItemStackable.MaxStackCount - readOnlyStorageSlot.Count, quantity);
			int quantity2 = readOnlyStorageSlot.Count - num;
			storage.SetItem(index, item, quantity2);
			return quantity - num;
		}

		public static int RemoveItem(this IStorage storage, int index, int quantity = 1)
		{
			IReadOnlyStorageSlot readOnlyStorageSlot = storage[index];
			int num = Mathf.Min(readOnlyStorageSlot.Count, quantity);
			int num2 = readOnlyStorageSlot.Count - num;
			if (num2 > 0)
			{
				storage.SetItem(index, readOnlyStorageSlot.Item, num2);
			}
			else
			{
				storage.ClearItem(index);
			}
			return quantity - num;
		}
	}
}
