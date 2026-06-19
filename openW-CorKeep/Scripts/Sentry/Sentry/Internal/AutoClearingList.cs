using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sentry.Internal
{
	internal class AutoClearingList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly IList<T> _list;

		private bool _clearOnNextAdd;

		public int Count => _list.Count;

		public bool IsReadOnly => _list.IsReadOnly;

		public T this[int index]
		{
			get
			{
				return _list[index];
			}
			set
			{
				_list[index] = value;
			}
		}

		public AutoClearingList(IEnumerable<T> initialItems, bool clearOnNextAdd)
		{
			_list = initialItems.ToList();
			_clearOnNextAdd = clearOnNextAdd;
		}

		public void Add(T item)
		{
			if (_clearOnNextAdd)
			{
				Clear();
				_clearOnNextAdd = false;
			}
			_list.Add(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_list).GetEnumerator();
		}

		public void Clear()
		{
			_list.Clear();
		}

		public bool Contains(T item)
		{
			return _list.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			_list.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			return _list.Remove(item);
		}

		public int IndexOf(T item)
		{
			return _list.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			if (_clearOnNextAdd)
			{
				Clear();
				_clearOnNextAdd = false;
			}
			_list.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			_list.RemoveAt(index);
		}
	}
}
