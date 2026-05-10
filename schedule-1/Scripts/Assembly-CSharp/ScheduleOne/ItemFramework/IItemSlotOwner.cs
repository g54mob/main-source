using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;

namespace ScheduleOne.ItemFramework
{
	public interface IItemSlotOwner
	{
		List<ItemSlot> ItemSlots { get; set; }

		void SetStoredInstance(NetworkConnection conn, int itemSlotIndex, ItemInstance instance);

		void SetItemSlotQuantity(int itemSlotIndex, int quantity);

		void SetSlotLocked(NetworkConnection conn, int itemSlotIndex, bool locked, NetworkObject lockOwner, string lockReason);

		void SetSlotFilter(NetworkConnection conn, int itemSlotIndex, SlotFilter filter);

		void SendItemSlotDataToClient(NetworkConnection conn)
		{
		}

		int GetQuantitySum()
		{
			return 0;
		}

		int GetQuantityOfItem(string id)
		{
			return 0;
		}

		int GetNonEmptySlotCount()
		{
			return 0;
		}

		ItemSlot GetFirstSlotContaining(string id)
		{
			return null;
		}
	}
}
