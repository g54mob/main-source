using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public abstract class UnmodifiableList : IList, ICollection, IEnumerable
	{
		public abstract int Count { get; }

		public abstract bool IsFixedSize { get; }

		public virtual bool IsReadOnly => false;

		public abstract bool IsSynchronized { get; }

		public abstract object SyncRoot { get; }

		public virtual object Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual int Add(object o)
		{
			return 0;
		}

		public virtual void Clear()
		{
		}

		public abstract bool Contains(object o);

		public abstract void CopyTo(Array array, int index);

		public abstract IEnumerator GetEnumerator();

		public abstract int IndexOf(object o);

		public virtual void Insert(int i, object o)
		{
		}

		public virtual void Remove(object o)
		{
		}

		public virtual void RemoveAt(int i)
		{
		}

		protected abstract object GetValue(int i);
	}
}
