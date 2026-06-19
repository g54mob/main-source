using System;
using System.Collections.Generic;

namespace Data.Save
{
	[Serializable]
	public struct InventorySaveData
	{
		public List<InventoryItemSaveData> Items;
	}
}
