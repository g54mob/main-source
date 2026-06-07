using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Mirror
{
	public class SyncSet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable, SyncObject
	{
		public delegate void SyncSetChanged(Operation op, T item);

		public enum Operation : byte
		{
			OP_ADD = 0,
			OP_CLEAR = 1,
			OP_REMOVE = 2
		}

		private struct Change
		{
			internal Operation operation;

			internal T item;
		}

		protected readonly ISet<T> objects;

		private readonly List<Change> changes;

		private int changesAhead;

		public int Count => 0;

		public bool IsReadOnly { get; private set; }

		public bool IsDirty => false;

		public event SyncSetChanged Callback
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

		public SyncSet(ISet<T> objects)
		{
		}

		public void Reset()
		{
		}

		public void Flush()
		{
		}

		private void AddOperation(Operation op, T item)
		{
		}

		private void AddOperation(Operation op)
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

		public bool Add(T item)
		{
			return false;
		}

		void ICollection<T>.Add(T item)
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

		public bool Remove(T item)
		{
			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void ExceptWith(IEnumerable<T> other)
		{
		}

		public void IntersectWith(IEnumerable<T> other)
		{
		}

		private void IntersectWithSet(ISet<T> otherSet)
		{
		}

		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			return false;
		}

		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			return false;
		}

		public bool IsSubsetOf(IEnumerable<T> other)
		{
			return false;
		}

		public bool IsSupersetOf(IEnumerable<T> other)
		{
			return false;
		}

		public bool Overlaps(IEnumerable<T> other)
		{
			return false;
		}

		public bool SetEquals(IEnumerable<T> other)
		{
			return false;
		}

		public void SymmetricExceptWith(IEnumerable<T> other)
		{
		}

		public void UnionWith(IEnumerable<T> other)
		{
		}
	}
}
