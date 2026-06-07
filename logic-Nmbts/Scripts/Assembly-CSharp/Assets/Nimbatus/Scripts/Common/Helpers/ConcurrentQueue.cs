using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class ConcurrentQueue<T> : IEnumerable<T>, IEnumerable, ICollection, ISerializable, IDeserializationCallback
	{
		private class Node
		{
			public T Value;

			public Node Next;
		}

		private Node _head = new Node();

		private Node _tail;

		private int _count;

		private readonly object _syncRoot = new object();

		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				return _syncRoot;
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return _count == 0;
			}
		}

		public ConcurrentQueue()
		{
			_tail = _head;
		}

		public ConcurrentQueue(IEnumerable<T> enumerable)
			: this()
		{
			foreach (T item in enumerable)
			{
				Enqueue(item);
			}
		}

		public void Enqueue(T item)
		{
			Node value = new Node
			{
				Value = item
			};
			Node node = null;
			bool flag = false;
			while (!flag)
			{
				node = _tail;
				Node next = node.Next;
				if (_tail == node)
				{
					if (next == null)
					{
						flag = Interlocked.CompareExchange(ref _tail.Next, value, null) == null;
					}
					else
					{
						Interlocked.CompareExchange(ref _tail, next, node);
					}
				}
			}
			Interlocked.CompareExchange(ref _tail, value, node);
			Interlocked.Increment(ref _count);
		}

		public bool TryDequeue(out T value)
		{
			value = default(T);
			bool flag = false;
			while (!flag)
			{
				Node head = _head;
				Node tail = _tail;
				Node next = head.Next;
				if (head != _head)
				{
					continue;
				}
				if (head == tail)
				{
					if (next != null)
					{
						Interlocked.CompareExchange(ref _tail, next, tail);
					}
					value = default(T);
					return false;
				}
				value = next.Value;
				flag = Interlocked.CompareExchange(ref _head, next, head) == head;
			}
			Interlocked.Decrement(ref _count);
			return true;
		}

		public bool TryPeek(out T value)
		{
			if (IsEmpty)
			{
				value = default(T);
				return false;
			}
			Node next = _head.Next;
			value = next.Value;
			return true;
		}

		public void Clear()
		{
			_count = 0;
			_tail = (_head = new Node());
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return InternalGetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return InternalGetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return InternalGetEnumerator();
		}

		private IEnumerator<T> InternalGetEnumerator()
		{
			Node myHead = _head;
			while (true)
			{
				Node next;
				myHead = (next = myHead.Next);
				if (next != null)
				{
					yield return myHead.Value;
					continue;
				}
				break;
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			T[] array2 = array as T[];
			if (array2 != null)
			{
				CopyTo(array2, index);
			}
		}

		public void CopyTo(T[] dest, int index)
		{
			IEnumerator<T> enumerator = InternalGetEnumerator();
			int num = index;
			while (enumerator.MoveNext())
			{
				dest[num++] = enumerator.Current;
			}
		}

		public T[] ToArray()
		{
			T[] array = new T[_count];
			CopyTo(array, 0);
			return array;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}

		public void OnDeserialization(object sender)
		{
			throw new NotImplementedException();
		}
	}
}
