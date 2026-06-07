using System.Collections.Generic;

namespace WaveHarmonic.Crest.Utility.Internal
{
	public sealed class Stack<T>
	{
		private readonly List<T> _Items = new List<T>();

		public int Count => _Items.Count;

		internal Stack()
		{
		}

		public void Push(T item)
		{
			Pop(item);
			_Items.Add(item);
		}

		public void Pop(T item)
		{
			_Items.RemoveAll((T candidate) => candidate.Equals(item));
		}

		public T Peek()
		{
			List<T> items = _Items;
			return items[items.Count - 1];
		}

		internal void Clear()
		{
			_Items.Clear();
		}
	}
}
