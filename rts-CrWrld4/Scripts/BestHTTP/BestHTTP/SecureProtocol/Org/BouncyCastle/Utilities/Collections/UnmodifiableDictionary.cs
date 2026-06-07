using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public abstract class UnmodifiableDictionary : IDictionary, ICollection, IEnumerable
	{
		public abstract int Count { get; }

		public abstract bool IsFixedSize { get; }

		public virtual bool IsReadOnly => false;

		public abstract bool IsSynchronized { get; }

		public abstract object SyncRoot { get; }

		public abstract ICollection Keys { get; }

		public abstract ICollection Values { get; }

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

		public virtual void Add(object k, object v)
		{
		}

		public virtual void Clear()
		{
		}

		public abstract bool Contains(object k);

		public abstract void CopyTo(Array array, int index);

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public abstract IDictionaryEnumerator GetEnumerator();

		public virtual void Remove(object k)
		{
		}

		protected abstract object GetValue(object k);
	}
}
