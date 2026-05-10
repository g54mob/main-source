using System.Collections.Generic;
using ScheduleOne.ItemFramework;

namespace ScheduleOne.Persistence.Datas
{
	public class DeserializedItemSet
	{
		public ItemInstance[] Items;

		public SlotFilter[] SlotFilters;

		public ItemInstance GetItemAt(int index)
		{
			return null;
		}

		public SlotFilter GetSlotFilterAt(int index)
		{
			return null;
		}

		public void LoadTo(List<ItemSlot> slots)
		{
		}
	}
}
