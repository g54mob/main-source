using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.StorageSystem
{
	[Serializable]
	public abstract class StorageBase : IStorage, IEnumerable<IReadOnlyStorageSlot>, IEnumerable
	{
		[SerializeField]
		protected List<StorageSlot> slots = new List<StorageSlot>();

		public virtual int Size => slots.Count;

		public virtual IReadOnlyStorageSlot this[int index] => slots[index];

		public event Action<IStorage> StorageChanged;

		public StorageBase(int size)
		{
			for (int i = 0; i < size; i++)
			{
				slots.Add(new StorageSlot(this, i));
			}
		}

		public virtual int AddItem(IStorageItem item, int quantity = 1)
		{
			return AddItem(item, quantity, sendcallback: true);
		}

		public virtual int SetItem(int index, IStorageItem item, int quantity = 1)
		{
			return SetItem(index, item, quantity, sendcallback: true);
		}

		public virtual void ClearItem(int index)
		{
			ClearItem(index, sendcallback: true);
		}

		public virtual void Clear()
		{
			Clear(sendcallback: true);
		}

		protected int AddItem(IStorageItem item, int quantity, bool sendcallback)
		{
			for (int i = 0; i < slots.Count || quantity <= 0; i++)
			{
				quantity = AddItem(i, item, quantity, sendcallback: false);
			}
			if (sendcallback)
			{
				StorageChangedInvoke();
			}
			return quantity;
		}

		protected int AddItem(int index, IStorageItem item, int quantity, bool sendcallback)
		{
			StorageSlot storageSlot = slots[index];
			if (storageSlot.IsEmpty())
			{
				return SetItem(index, item, quantity, sendcallback);
			}
			if (!(item is IStorageItemStackable item2) || !(storageSlot.Item is IStorageItemStackable storageItemStackable))
			{
				return quantity;
			}
			if (!storageItemStackable.CanStackWith(item2))
			{
				return quantity;
			}
			return SetItem(index, item, storageSlot.Count + quantity, sendcallback);
		}

		protected int SetItem(int index, IStorageItem item, int quantity, bool sendcallback)
		{
			int num = Mathf.Min((!(item is IStorageItemStackable storageItemStackable)) ? 1 : storageItemStackable.MaxStackCount, quantity);
			slots[index].Set(item, num);
			if (sendcallback)
			{
				StorageChangedInvoke();
			}
			return quantity - num;
		}

		protected void ClearItem(int index, bool sendcallback)
		{
			slots[index].Clear();
			if (sendcallback)
			{
				StorageChangedInvoke();
			}
		}

		protected void Clear(bool sendcallback)
		{
			for (int i = 0; i < slots.Count; i++)
			{
				slots[i].Clear();
			}
			if (sendcallback)
			{
				StorageChangedInvoke();
			}
		}

		public IEnumerator<IReadOnlyStorageSlot> GetEnumerator()
		{
			return slots.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return slots.GetEnumerator();
		}

		protected void StorageChangedInvoke()
		{
			this.StorageChanged?.Invoke(this);
		}
	}
}
