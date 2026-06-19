using System;

namespace Data.Save
{
	[Serializable]
	public struct InventoryItemSaveData
	{
		public string InstanceId;

		public string AddressableKey;

		public bool IsSceneItem;
	}
}
