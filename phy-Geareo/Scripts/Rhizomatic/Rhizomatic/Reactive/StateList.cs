using System.Collections;
using System.Collections.Generic;

namespace Rhizomatic.Reactive
{
	public class StateList<T> : State<List<T>>, IEnumerable<T>, IEnumerable
	{
		public T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public int Count => 0;

		public StateList(List<T> defaultValue = null)
			: base((List<T>)default(T))
		{
		}

		public void Add(T item)
		{
		}

		public void AddRange(IEnumerable<T> items)
		{
		}

		public void Insert(int index, T item)
		{
		}

		public void Remove(T item)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public void Clear()
		{
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
