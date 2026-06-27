using System;

namespace Restory.StorageSystem
{
	public interface IReadOnlyStorageSlot
	{
		IStorage Owner { get; }

		int Index { get; }

		IStorageItem Item { get; }

		int Count { get; }

		event Action<IReadOnlyStorageSlot> SlotChanged;

		bool IsEmpty();
	}
}
