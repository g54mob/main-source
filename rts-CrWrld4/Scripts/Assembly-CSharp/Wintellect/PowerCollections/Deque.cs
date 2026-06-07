using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public class Deque<T> : ListBase<T>, ICloneable
	{
		private const int INITIAL_SIZE = 8;

		private T[] buffer;

		private int start;

		private int end;

		private int changeStamp;

		public sealed override int Count => 0;

		public int Capacity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public sealed override T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		private void StopEnumerations()
		{
		}

		private void CheckEnumerationStamp(int startStamp)
		{
		}

		public Deque()
		{
		}

		public Deque(IEnumerable<T> collection)
		{
		}

		public sealed override void CopyTo(T[] array, int arrayIndex)
		{
		}

		public void TrimToSize()
		{
		}

		public sealed override void Clear()
		{
		}

		public sealed override IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		private void CreateInitialBuffer(T firstItem)
		{
		}

		public sealed override void Insert(int index, T item)
		{
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
		}

		public sealed override void RemoveAt(int index)
		{
		}

		public void RemoveRange(int index, int count)
		{
		}

		private void IncreaseBuffer()
		{
		}

		public void AddToFront(T item)
		{
		}

		public void AddManyToFront(IEnumerable<T> collection)
		{
		}

		public void AddToBack(T item)
		{
		}

		public sealed override void Add(T item)
		{
		}

		public void AddManyToBack(IEnumerable<T> collection)
		{
		}

		public T RemoveFromFront()
		{
			return default(T);
		}

		public T RemoveFromBack()
		{
			return default(T);
		}

		public T GetAtFront()
		{
			return default(T);
		}

		public T GetAtBack()
		{
			return default(T);
		}

		public Deque<T> Clone()
		{
			return null;
		}

		object ICloneable.Clone()
		{
			return null;
		}

		public Deque<T> CloneContents()
		{
			return null;
		}
	}
}
