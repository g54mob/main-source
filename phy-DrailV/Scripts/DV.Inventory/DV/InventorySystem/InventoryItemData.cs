using UnityEngine;

namespace DV.InventorySystem
{
	internal class InventoryItemData
	{
		public static readonly InventoryItemData Empty = new InventoryItemData(null, isReserved: false, isDropped: false);

		public GameObject item;

		public bool IsLocked { get; private set; }

		public bool IsReserved { get; private set; }

		public bool IsDropped { get; private set; }

		public InventoryItemData(GameObject item, bool isLocked, bool isReserved, bool isDropped)
		{
			this.item = item;
			IsLocked = isLocked;
			IsReserved = isReserved;
			IsDropped = isDropped;
		}

		public InventoryItemData(GameObject item, bool isReserved, bool isDropped)
		{
			this.item = item;
			IsLocked = false;
			IsReserved = isReserved;
			IsDropped = isDropped;
		}

		public void ToggleLock(bool shouldLock)
		{
			IsLocked = shouldLock;
		}

		public void ToggleReserve(bool shouldReserve)
		{
			IsReserved = shouldReserve;
		}

		public void ToggleDropped(bool shouldDrop)
		{
			IsDropped = shouldDrop;
			if (IsLocked)
			{
				IsReserved = shouldDrop;
			}
		}
	}
}
