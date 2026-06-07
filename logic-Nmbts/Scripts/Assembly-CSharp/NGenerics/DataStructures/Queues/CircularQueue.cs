using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.DataStructures.Queues
{
	[Serializable]
	public class CircularQueue<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IQueue<T>
	{
		private const string queueIsEmpty = "The Queue is empty.";

		private readonly LinkedList<T> data = new LinkedList<T>();

		private readonly int capacity;

		public bool IsEmpty
		{
			get
			{
				return data.Count == 0;
			}
		}

		public bool IsFull
		{
			get
			{
				return data.Count == capacity;
			}
		}

		public int Count
		{
			get
			{
				return data.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public int Capacity
		{
			get
			{
				return capacity;
			}
		}

		public CircularQueue(int capacity)
		{
			if (capacity < 1)
			{
				throw new ArgumentException("Capacity can not be less than 1.", "capacity");
			}
			this.capacity = capacity;
		}

		public void Enqueue(T item)
		{
			EnqueueItem(item);
		}

		protected virtual void EnqueueItem(T item)
		{
			if (data.Count == capacity)
			{
				data.RemoveFirst();
			}
			data.AddLast(item);
		}

		public T Dequeue()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("The Queue is empty.");
			}
			return DequeueItem();
		}

		protected virtual T DequeueItem()
		{
			T value = data.First.Value;
			data.RemoveFirst();
			return value;
		}

		public T Peek()
		{
			if (IsEmpty)
			{
				throw new InvalidOperationException("The Queue is empty.");
			}
			return data.First.Value;
		}

		void ICollection<T>.Add(T item)
		{
			Enqueue(item);
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			data.Clear();
		}

		public bool Contains(T item)
		{
			if (!IsEmpty)
			{
				return data.Contains(item);
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (!IsEmpty)
			{
				data.CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(T item)
		{
			return RemoveItem(item);
		}

		protected virtual bool RemoveItem(T item)
		{
			return data.Remove(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
