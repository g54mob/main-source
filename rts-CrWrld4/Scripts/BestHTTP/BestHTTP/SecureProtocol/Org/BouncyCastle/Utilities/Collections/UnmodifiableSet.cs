using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public abstract class UnmodifiableSet : ISet, ICollection, IEnumerable
	{
		public abstract int Count { get; }

		public abstract bool IsEmpty { get; }

		public abstract bool IsFixedSize { get; }

		public virtual bool IsReadOnly => false;

		public abstract bool IsSynchronized { get; }

		public abstract object SyncRoot { get; }

		public virtual void Add(object o)
		{
		}

		public virtual void AddAll(IEnumerable e)
		{
		}

		public virtual void Clear()
		{
		}

		public abstract bool Contains(object o);

		public abstract void CopyTo(Array array, int index);

		public abstract IEnumerator GetEnumerator();

		public virtual void Remove(object o)
		{
		}

		public virtual void RemoveAll(IEnumerable e)
		{
		}
	}
}
