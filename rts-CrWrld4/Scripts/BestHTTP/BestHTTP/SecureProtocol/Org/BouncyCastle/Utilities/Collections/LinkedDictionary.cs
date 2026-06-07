using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public class LinkedDictionary : IDictionary, ICollection, IEnumerable
	{
		internal readonly IDictionary hash;

		internal readonly IList keys;

		public virtual int Count => 0;

		public virtual bool IsFixedSize => false;

		public virtual bool IsReadOnly => false;

		public virtual bool IsSynchronized => false;

		public virtual object SyncRoot => null;

		public virtual ICollection Keys => null;

		public virtual ICollection Values => null;

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

		public virtual bool Contains(object k)
		{
			return false;
		}

		public virtual void CopyTo(Array array, int index)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return null;
		}

		public virtual void Remove(object k)
		{
		}
	}
}
