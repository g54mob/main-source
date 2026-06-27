using System;
using System.Collections.Generic;
using Restory.StorageSystem.StorageElements;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class InventorySaveData
	{
		public List<StorageItemElement> StorageItems;
	}
}
