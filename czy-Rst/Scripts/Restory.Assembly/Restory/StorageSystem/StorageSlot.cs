using System;
using UnityEngine;

namespace Restory.StorageSystem
{
	[Serializable]
	public class StorageSlot : IStorageSlot, IReadOnlyStorageSlot
	{
		private readonly StorageBase owner;

		private int index;

		[SerializeReference]
		private IStorageItem item;

		[SerializeField]
		private int count;

		public int Index
		{
			get
			{
				return index;
			}
			set
			{
				index = value;
			}
		}

		public IStorageItem Item
		{
			get
			{
				return item;
			}
			set
			{
				item = value;
			}
		}

		public int Count
		{
			get
			{
				return count;
			}
			set
			{
				count = value;
			}
		}

		public IStorage Owner => owner;

		public event Action<IReadOnlyStorageSlot> SlotChanged;

		public StorageSlot(StorageBase owner, int index)
			: this(owner, index, null, 0)
		{
		}

		public StorageSlot(StorageBase owner, int index, IStorageItem item, int count = 1)
		{
			this.owner = owner;
			this.index = index;
			Set(item, count);
		}

		public bool IsEmpty()
		{
			if (item != null)
			{
				return count == 0;
			}
			return true;
		}

		public void Set(IStorageItem item, int count = 1)
		{
			this.item = item;
			this.count = count;
			SlotChangedInvoke();
		}

		public void Clear()
		{
			item = null;
			count = 0;
			SlotChangedInvoke();
		}

		protected void SlotChangedInvoke()
		{
			this.SlotChanged?.Invoke(this);
		}
	}
}
