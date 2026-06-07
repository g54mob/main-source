using Brewery.Shelf;
using InventorySystem;
using UnityEngine;
using Vehicle.VanShelf;

namespace Brewery.Thief
{
	public struct TheftTarget
	{
		public enum StorageType
		{
			Bar = 0,
			Shelf = 1,
			VanShelf = 2,
			VehicleRack = 3
		}

		private BarInventoryManager barManager;

		private ShelfInventoryManager shelfManager;

		private VanShelfInventoryManager vanShelfManager;

		private VehicleInventoryManager vehicleManager;

		public StorageType Type { get; private set; }

		public Transform Transform { get; private set; }

		public ulong NetworkObjectId { get; private set; }

		public bool IsValid => false;

		public Vector3 Position => default(Vector3);

		public string DisplayName => null;

		public static TheftTarget FromBar(BarInventoryManager bar)
		{
			return default(TheftTarget);
		}

		public static TheftTarget FromShelf(ShelfInventoryManager shelf)
		{
			return default(TheftTarget);
		}

		public static TheftTarget FromVanShelf(VanShelfInventoryManager vanShelf)
		{
			return default(TheftTarget);
		}

		public static TheftTarget FromVehicle(VehicleInventoryManager vehicle)
		{
			return default(TheftTarget);
		}

		public InventorySlot[] GetAllSlots()
		{
			return null;
		}

		public InventorySlot GetSlot(int index)
		{
			return null;
		}

		public void TriggerSlotChanged(int slotIndex)
		{
		}

		public int GetTotalItemCount()
		{
			return 0;
		}

		public float GetEstimatedValue()
		{
			return 0f;
		}
	}
}
