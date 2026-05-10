using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;

namespace FishNet.Object.Synchronizing
{
	public class SyncHashSet<T> : SyncBase, ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private struct CachedOnChange
		{
			internal readonly SyncHashSetOperation Operation;

			internal readonly T Item;

			public CachedOnChange(SyncHashSetOperation operation, T item)
			{
				Operation = default(SyncHashSetOperation);
				Item = default(T);
			}
		}

		private struct ChangeData
		{
			internal readonly SyncHashSetOperation Operation;

			internal readonly T Item;

			public ChangeData(SyncHashSetOperation operation, T item)
			{
				Operation = default(SyncHashSetOperation);
				Item = default(T);
			}
		}

		[APIExclude]
		public delegate void SyncHashSetChanged(SyncHashSetOperation op, T item, bool asServer);

		public readonly ISet<T> Collection;

		public readonly ISet<T> ClientHostCollection;

		private static List<T> _cache;

		private ISet<T> _initialValues;

		private readonly IEqualityComparer<T> _comparer;

		private readonly List<ChangeData> _changed;

		private readonly List<CachedOnChange> _serverOnChanges;

		private readonly List<CachedOnChange> _clientOnChanges;

		private bool _valuesChanged;

		private bool _sendAll;

		[APIExclude]
		public bool IsReadOnly => false;

		public int Count => 0;

		public event SyncHashSetChanged OnChange
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

		[APIExclude]
		public SyncHashSet()
		{
		}

		[APIExclude]
		public SyncHashSet(IEqualityComparer<T> comparer)
		{
		}

		[APIExclude]
		public SyncHashSet(ISet<T> collection, IEqualityComparer<T> comparer = null)
		{
		}

		protected override void Registered()
		{
		}

		public HashSet<T> GetCollection(bool asServer)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddOperation(SyncHashSetOperation operation, T item)
		{
		}

		public override void OnStartCallback(bool asServer)
		{
		}

		public override void WriteDelta(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		public override void WriteFull(PooledWriter writer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public override void Read(PooledReader reader, bool asServer)
		{
		}

		private void InvokeOnChange(SyncHashSetOperation operation, T item, bool asServer)
		{
		}

		public override void ResetState()
		{
		}

		public bool Add(T item)
		{
			return false;
		}

		private bool Add(T item, bool asServer)
		{
			return false;
		}

		public void AddRange(IEnumerable<T> range)
		{
		}

		public void Clear()
		{
		}

		private void Clear(bool asServer)
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public bool Remove(T item)
		{
			return false;
		}

		private bool Remove(T item, bool asServer)
		{
			return false;
		}

		public void DirtyAll()
		{
		}

		public void Dirty(T obj)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		[APIExclude]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		[APIExclude]
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

		private void IntersectWith(ISet<T> other)
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

		void ICollection<T>.Add(T item)
		{
		}

		public void CopyTo(T[] array, int index)
		{
		}
	}
}
