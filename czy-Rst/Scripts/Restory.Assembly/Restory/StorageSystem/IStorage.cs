using System;

namespace Restory.StorageSystem
{
	public interface IStorage
	{
		int Size { get; }

		IReadOnlyStorageSlot this[int index] { get; }

		event Action<IStorage> StorageChanged;

		int AddItem(IStorageItem item, int quantity = 1);

		int SetItem(int index, IStorageItem item, int quantity = 1);

		void ClearItem(int index);

		void Clear();
	}
}
