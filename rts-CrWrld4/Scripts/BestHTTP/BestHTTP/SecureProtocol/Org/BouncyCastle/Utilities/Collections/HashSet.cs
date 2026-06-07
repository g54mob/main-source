using System;
using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections
{
	public class HashSet : ISet, ICollection, IEnumerable
	{
		private readonly IDictionary impl;

		public virtual int Count => 0;

		public virtual bool IsEmpty => false;

		public virtual bool IsFixedSize => false;

		public virtual bool IsReadOnly => false;

		public virtual bool IsSynchronized => false;

		public virtual object SyncRoot => null;

		public HashSet()
		{
		}

		public HashSet(IEnumerable s)
		{
		}

		public virtual void Add(object o)
		{
		}

		public virtual void AddAll(IEnumerable e)
		{
		}

		public virtual void Clear()
		{
		}

		public virtual bool Contains(object o)
		{
			return false;
		}

		public virtual void CopyTo(Array array, int index)
		{
		}

		public virtual IEnumerator GetEnumerator()
		{
			return null;
		}

		public virtual void Remove(object o)
		{
		}

		public virtual void RemoveAll(IEnumerable e)
		{
		}
	}
}
