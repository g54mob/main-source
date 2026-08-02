using System.Collections.Generic;

namespace MoonSharp.Interpreter.DataStructs
{
	internal class MultiDictionary<K, V>
	{
		private Dictionary<K, List<V>> m_Map;

		private V[] m_DefaultRet;

		public IEnumerable<K> Keys => null;

		public MultiDictionary()
		{
		}

		public MultiDictionary(IEqualityComparer<K> eqComparer)
		{
		}

		public bool Add(K key, V value)
		{
			return false;
		}

		public IEnumerable<V> Find(K key)
		{
			return null;
		}

		public bool ContainsKey(K key)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void Remove(K key)
		{
		}

		public bool RemoveValue(K key, V value)
		{
			return false;
		}
	}
}
