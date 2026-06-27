using System;

namespace Restory.StorageSystem.StorageElements
{
	[Serializable]
	public class StorageElasticElements : StorageElastic
	{
		public StorageElasticElements()
			: base(0)
		{
		}

		public StorageElasticElements(int size)
			: base(size)
		{
		}

		public override int AddItem(IStorageItem item, int quantity = 1)
		{
			if (!(item is StorageItemElement))
			{
				return quantity;
			}
			return base.AddItem(item, quantity);
		}

		public override int SetItem(int index, IStorageItem item, int quantity = 1)
		{
			if (!(item is StorageItemElement))
			{
				return quantity;
			}
			return base.SetItem(index, item, quantity);
		}
	}
}
