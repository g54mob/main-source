using System;
using System.Collections;

namespace Castle.Components.DictionaryAdapter
{
	public abstract class AbstractDictionaryAdapter : IDictionary, ICollection, IEnumerable
	{
		public bool IsFixedSize
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public abstract bool IsReadOnly { get; }

		public ICollection Keys
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public ICollection Values
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public abstract object this[object key] { get; set; }

		public int Count
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public virtual bool IsSynchronized => false;

		public virtual object SyncRoot => this;

		public void Add(object key, object value)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public abstract bool Contains(object key);

		public IDictionaryEnumerator GetEnumerator()
		{
			throw new NotSupportedException();
		}

		public void Remove(object key)
		{
			throw new NotSupportedException();
		}

		public void CopyTo(Array array, int index)
		{
			throw new NotSupportedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotSupportedException();
		}
	}
}
