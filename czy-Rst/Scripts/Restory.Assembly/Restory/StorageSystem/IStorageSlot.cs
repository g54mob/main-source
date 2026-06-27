using System;

namespace Restory.StorageSystem
{
	public interface IStorageSlot
	{
		IStorage Owner { get; }

		int Index { get; set; }

		IStorageItem Item { get; set; }

		int Count { get; set; }

		event Action<IReadOnlyStorageSlot> SlotChanged;

		bool IsEmpty();

		void Set(IStorageItem item, int count = 1);

		void Clear();
	}
}
