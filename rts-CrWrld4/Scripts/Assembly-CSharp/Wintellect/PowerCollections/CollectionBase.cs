using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public abstract class CollectionBase<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ICollection
	{
		public abstract int Count { get; }

		bool ICollection<T>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		public override string ToString()
		{
			return null;
		}

		public virtual void Add(T item)
		{
		}

		public abstract void Clear();

		public abstract bool Remove(T item);

		public virtual bool Contains(T item)
		{
			return false;
		}

		public virtual void CopyTo(T[] array, int arrayIndex)
		{
		}

		public virtual T[] ToArray()
		{
			return null;
		}

		public virtual ICollection<T> AsReadOnly()
		{
			return null;
		}

		public virtual bool Exists(Predicate<T> predicate)
		{
			return false;
		}

		public virtual bool TrueForAll(Predicate<T> predicate)
		{
			return false;
		}

		public virtual int CountWhere(Predicate<T> predicate)
		{
			return 0;
		}

		public virtual IEnumerable<T> FindAll(Predicate<T> predicate)
		{
			return null;
		}

		public virtual ICollection<T> RemoveAll(Predicate<T> predicate)
		{
			return null;
		}

		public virtual void ForEach(Action<T> action)
		{
		}

		public virtual IEnumerable<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			return null;
		}

		public abstract IEnumerator<T> GetEnumerator();

		void ICollection.CopyTo(Array array, int index)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		internal string DebuggerDisplayString()
		{
			return null;
		}
	}
}
