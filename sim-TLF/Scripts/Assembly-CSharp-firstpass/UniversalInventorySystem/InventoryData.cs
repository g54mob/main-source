using System;

namespace UniversalInventorySystem
{
	[Serializable]
	public struct InventoryData
	{
		public Inventory[] inventories;

		public Inventory this[int i] => inventories[i];
	}
}
