using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;

namespace FishNet.Object.Synchronizing
{
	public class SyncList<T> : SyncBase, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T>
	{
		private struct CachedOnChange
		{
			internal readonly SyncListOperation Operation;

			internal readonly int Index;

			internal readonly T Previous;

			internal readonly T Next;

			public CachedOnChange(SyncListOperation operation, int index, T previous, T next)
			{
				Operation = default(SyncListOperation);
				Index = 0;
				Previous = default(T);
				Next = default(T);
			}
		}

		private struct ChangeData
		{
			internal readonly SyncListOperation Operation;

			internal readonly int Index;

			internal readonly T Item;

			public ChangeData(SyncListOperation operation, int index, T item)
			{
				Operation = default(SyncListOperation);
				Index = 0;
				Item = default(T);
			}
		}

		[APIExclude]
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private readonly SyncList<T> _list;

			private int _index;

			public T Current { get; private set; }

			object IEnumerator.Current => null;

			public Enumerator(SyncList<T> list)
			{
				Current = default(T);
				_list = null;
				_index = 0;
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

		[APIExclude]
		public delegate void SyncListChanged(SyncListOperation op, int index, T oldItem, T newItem, bool asServer);

		public readonly IList<T> Collection;

		public readonly IList<T> ClientHostCollection;

		private IList<T> _initialValues;

		private readonly IEqualityComparer<T> _comparer;

		private readonly List<ChangeData> _changed;

		private readonly List<CachedOnChange> _serverOnChanges;

		private readonly List<CachedOnChange> _clientOnChanges;

		private bool _valuesChanged;

		private bool _sendAll;

		[APIExclude]
		public bool IsReadOnly => false;

		public int Count => 0;

		public T this[int i]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public event SyncListChanged OnChange
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
		public SyncList()
		{
		}

		[APIExclude]
		public SyncList(IEqualityComparer<T> comparer)
		{
		}

		[APIExclude]
		public SyncList(IList<T> collection, IEqualityComparer<T> comparer = null)
		{
		}

		protected override void Registered()
		{
		}

		public List<T> GetCollection(bool asServer)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddOperation(SyncListOperation operation, int index, T prev, T next)
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

		private void InvokeOnChange(SyncListOperation operation, int index, T prev, T next, bool asServer)
		{
		}

		public override void ResetState()
		{
		}

		public void Add(T item)
		{
		}

		private void Add(T item, bool asServer)
		{
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

		private void Insert(int index, T item, bool asServer)
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

		private void RemoveAt(int index, bool asServer)
		{
		}

		public int RemoveAll(Predicate<T> match)
		{
			return 0;
		}

		public void DirtyAll()
		{
		}

		public void Dirty(T obj)
		{
		}

		public void Dirty(int index)
		{
		}

		public void Set(int index, T value, bool force = true)
		{
		}

		private void Set(int index, T value, bool asServer, bool force)
		{
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
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
	}
}
