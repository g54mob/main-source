using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ObservableCollections
{
	public abstract class NotifyCollectionChangedSynchronizedViewList<TView> : INotifyCollectionChangedSynchronizedViewList<TView>, IList<TView>, ICollection<TView>, IEnumerable<TView>, IEnumerable, IList, ICollection, ISynchronizedViewList<TView>, IReadOnlyList<TView>, IReadOnlyCollection<TView>, IDisposable, INotifyCollectionChanged, INotifyPropertyChanged, IWritableSynchronizedViewList<TView>
	{
		protected readonly object gate = new object();

		public abstract TView this[int index] { get; set; }

		object? IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				((IList<TView>)this)[index] = (TView)value;
			}
		}

		public abstract int Count { get; }

		public virtual bool IsReadOnly { get; } = true;

		public bool IsFixedSize => IsReadOnly;

		public bool IsSynchronized => true;

		public object SyncRoot => gate;

		public abstract event NotifyCollectionChangedEventHandler? CollectionChanged;

		public abstract event PropertyChangedEventHandler? PropertyChanged;

		public abstract void Add(TView item);

		int IList.Add(object? value)
		{
			Add((TView)value);
			return Count - 1;
		}

		public abstract void Insert(int index, TView item);

		public abstract bool Remove(TView item);

		public abstract void RemoveAt(int index);

		public abstract void Clear();

		public abstract bool Contains(TView item);

		bool IList.Contains(object? value)
		{
			if (IsCompatibleObject(value))
			{
				return Contains((TView)value);
			}
			return false;
		}

		public abstract void Dispose();

		public abstract IEnumerator<TView> GetEnumerator();

		public abstract int IndexOf(TView item);

		int IList.IndexOf(object? item)
		{
			if (IsCompatibleObject(item))
			{
				return IndexOf((TView)item);
			}
			return -1;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private static bool IsCompatibleObject(object? value)
		{
			if (!(value is TView))
			{
				if (value == null)
				{
					return default(TView) == null;
				}
				return false;
			}
			return true;
		}

		void ICollection<TView>.Clear()
		{
			Clear();
		}

		void IList.Clear()
		{
			Clear();
		}

		void ICollection<TView>.CopyTo(TView[] array, int arrayIndex)
		{
			throw new NotSupportedException();
		}

		void ICollection.CopyTo(Array array, int index)
		{
			throw new NotSupportedException();
		}

		void IList<TView>.Insert(int index, TView item)
		{
			Insert(index, item);
		}

		void IList.Insert(int index, object? value)
		{
			Insert(index, (TView)value);
		}

		bool ICollection<TView>.Remove(TView item)
		{
			return Remove(item);
		}

		void IList.Remove(object? value)
		{
			Remove((TView)value);
		}

		void IList.RemoveAt(int index)
		{
			RemoveAt(index);
		}

		void IList<TView>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}
	}
}
