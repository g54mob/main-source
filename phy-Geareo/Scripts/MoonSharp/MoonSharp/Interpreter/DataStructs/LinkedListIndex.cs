using System.Collections.Generic;

namespace MoonSharp.Interpreter.DataStructs
{
	internal class LinkedListIndex<TKey, TValue>
	{
		private LinkedList<TValue> m_LinkedList;

		private Dictionary<TKey, LinkedListNode<TValue>> m_Map;

		public LinkedListIndex(LinkedList<TValue> linkedList)
		{
		}

		public LinkedListNode<TValue> Find(TKey key)
		{
			return null;
		}

		public TValue Set(TKey key, TValue value)
		{
			return default(TValue);
		}

		public void Add(TKey key, TValue value)
		{
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
