using System.Collections.Generic;

namespace GSpawn_Pro
{
	public class PriorityQueue<TData, TComparer> where TData : IPriorityQueueLocatableItem where TComparer : IComparer<TData>
	{
		private TComparer _comparer;

		private int _capacity;

		private TData[] _items;

		private int _numItems;

		public int NumItems => 0;

		public PriorityQueue(int capacity, TComparer comparer)
		{
		}

		public void Clear()
		{
		}

		public void Enqueue(TData item)
		{
		}

		public TData Dequeue()
		{
			return default(TData);
		}

		public void OnItemChangedPriority(TData item)
		{
		}

		private void HeapifyDown(int startIndex)
		{
		}

		private void HeapifyUp(int index)
		{
		}

		private void Swap(int index0, int index1)
		{
		}
	}
}
