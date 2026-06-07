using System;
using System.Collections;
using System.Collections.Generic;

namespace NGenerics.DataStructures.Queues
{
	[Serializable]
	public class Deque<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IDeque<T>
	{
		private const string dequeIsEmpty = "The deque is empty.";

		private readonly LinkedList<T> list;

		public T Head
		{
			get
			{
				if (list.Count == 0)
				{
					throw new InvalidOperationException("The deque is empty.");
				}
				return list.First.Value;
			}
		}

		public T Tail
		{
			get
			{
				if (list.Count == 0)
				{
					throw new InvalidOperationException("The deque is empty.");
				}
				return list.Last.Value;
			}
		}

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public Deque()
		{
			list = new LinkedList<T>();
		}

		public Deque(IEnumerable<T> collection)
		{
			list = new LinkedList<T>(collection);
		}

		public void EnqueueHead(T item)
		{
			EnqueueHeadItem(item);
		}

		protected virtual void EnqueueHeadItem(T item)
		{
			list.AddFirst(item);
		}

		public T DequeueHead()
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException("The deque is empty.");
			}
			return DequeueHeadItem();
		}

		protected virtual T DequeueHeadItem()
		{
			T value = list.First.Value;
			list.RemoveFirst();
			return value;
		}

		public void EnqueueTail(T item)
		{
			EnqueueTailItem(item);
		}

		protected virtual void EnqueueTailItem(T item)
		{
			list.AddLast(item);
		}

		public T DequeueTail()
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException("The deque is empty.");
			}
			return DequeueTailItem();
		}

		protected virtual T DequeueTailItem()
		{
			T value = list.Last.Value;
			list.RemoveLast();
			return value;
		}

		public bool Contains(T item)
		{
			return list.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			list.Clear();
		}

		void ICollection<T>.Add(T item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
