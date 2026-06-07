using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Mirror
{
	public class SyncList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>, SyncObject
	{
		public delegate void SyncListChanged(Operation op, int itemIndex, T oldItem, T newItem);

		public enum Operation : byte
		{
			OP_ADD = 0,
			OP_CLEAR = 1,
			OP_INSERT = 2,
			OP_REMOVEAT = 3,
			OP_SET = 4
		}

		private struct Change
		{
			internal Operation operation;

			internal int index;

			internal T item;
		}

		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private readonly SyncList<T> list;

			private int index;

			public T Current { get; private set; }

			object IEnumerator.Current => null;

			public Enumerator(SyncList<T> list)
			{
				this.list = null;
				index = 0;
				Current = default(T);
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}

			public void Dispose()
			{
			}
		}

		private readonly IList<T> objects;

		private readonly IEqualityComparer<T> comparer;

		private readonly List<Change> changes;

		private int changesAhead;

		public int Count => 0;

		public bool IsReadOnly { get; private set; }

		public bool IsDirty => false;

		public T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public event SyncListChanged Callback
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public SyncList()
		{
		}

		public SyncList(IEqualityComparer<T> comparer)
		{
		}

		public SyncList(IList<T> objects, IEqualityComparer<T> comparer = null)
		{
		}

		public void Flush()
		{
		}

		public void Reset()
		{
		}

		private void AddOperation(Operation op, int itemIndex, T oldItem, T newItem)
		{
		}

		public void OnSerializeAll(NetworkWriter writer)
		{
		}

		public void OnSerializeDelta(NetworkWriter writer)
		{
		}

		public void OnDeserializeAll(NetworkReader reader)
		{
		}

		public void OnDeserializeDelta(NetworkReader reader)
		{
		}

		public void Add(T item)
		{
		}

		public void AddRange(IEnumerable<T> range)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public void CopyTo(T[] array, int index)
		{
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public int FindIndex(Predicate<T> match)
		{
			return 0;
		}

		public T Find(Predicate<T> match)
		{
			return default(T);
		}

		public List<T> FindAll(Predicate<T> match)
		{
			return null;
		}

		public void Insert(int index, T item)
		{
		}

		public void InsertRange(int index, IEnumerable<T> range)
		{
		}

		public bool Remove(T item)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		public int RemoveAll(Predicate<T> match)
		{
			return 0;
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
