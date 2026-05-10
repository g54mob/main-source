namespace Gley.UrbanSystem.Internal
{
	public class Heap<T> where T : IHeapItem<T>
	{
		private readonly T[] _items;

		private int _currentItemCount;

		public int Count => 0;

		public Heap(int maxHeapSize)
		{
		}

		public void Add(T item)
		{
		}

		public T RemoveFirst()
		{
			return default(T);
		}

		public void UpdateItem(T item)
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		private void SortDown(T item)
		{
		}

		private void SortUp(T item)
		{
		}

		private void Swap(T itemA, T itemB)
		{
		}
	}
}
