using System;
using System.Collections.Generic;

[Serializable]
public struct PlayerInventorySync
{
	public string playerID;

	public List<InventorySaveData> inventoryData;
}
