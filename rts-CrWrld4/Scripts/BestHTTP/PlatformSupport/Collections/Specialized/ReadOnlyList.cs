using System;
using System.Collections;

namespace PlatformSupport.Collections.Specialized
{
	internal sealed class ReadOnlyList : IList, ICollection, IEnumerable
	{
		private readonly IList _list;

		public int Count => 0;

		public bool IsReadOnly => false;

		public bool IsFixedSize => false;

		public bool IsSynchronized => false;

		public object Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object SyncRoot => null;

		internal ReadOnlyList(IList list)
		{
		}

		public int Add(object value)
		{
			return 0;
		}

		public void Clear()
		{
		}

		public bool Contains(object value)
		{
			return false;
		}

		public void CopyTo(Array array, int index)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		public int IndexOf(object value)
		{
			return 0;
		}

		public void Insert(int index, object value)
		{
		}

		public void Remove(object value)
		{
		}

		public void RemoveAt(int index)
		{
		}
	}
}
