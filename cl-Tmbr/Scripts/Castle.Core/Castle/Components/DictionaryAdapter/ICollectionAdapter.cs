using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter
{
	public interface ICollectionAdapter<T>
	{
		IEqualityComparer<T> Comparer { get; }

		int Count { get; }

		T this[int index] { get; set; }

		bool HasSnapshot { get; }

		int SnapshotCount { get; }

		void Initialize(ICollectionAdapterObserver<T> advisor);

		T AddNew();

		bool Add(T value);

		bool Insert(int index, T value);

		void Remove(int index);

		void Clear();

		void ClearReferences();

		T GetCurrentItem(int index);

		T GetSnapshotItem(int index);

		void SaveSnapshot();

		void LoadSnapshot();

		void DropSnapshot();
	}
}
