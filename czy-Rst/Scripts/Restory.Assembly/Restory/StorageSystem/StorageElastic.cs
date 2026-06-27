using System;

namespace Restory.StorageSystem
{
	[Serializable]
	public class StorageElastic : StorageBase
	{
		public StorageElastic()
			: base(0)
		{
		}

		public StorageElastic(int size)
			: base(size)
		{
		}

		public override int AddItem(IStorageItem item, int quantity = 1)
		{
			for (quantity = AddItem(item, quantity, sendcallback: false); quantity >= 1; quantity = SetItem(slots.Count - 1, item, quantity, sendcallback: false))
			{
				slots.Add(new StorageSlot(this, slots.Count));
			}
			StorageChangedInvoke();
			return 0;
		}

		public override void ClearItem(int index)
		{
			ClearItem(index, sendcallback: false);
			slots.RemoveAt(index);
			for (int i = index; i < slots.Count; i++)
			{
				slots[i].Index = i;
			}
			StorageChangedInvoke();
		}

		public override void Clear()
		{
			Clear(sendcallback: false);
			slots.Clear();
			StorageChangedInvoke();
		}
	}
}
