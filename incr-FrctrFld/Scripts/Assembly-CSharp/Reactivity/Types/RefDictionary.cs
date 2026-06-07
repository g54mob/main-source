using System.Collections.Generic;

namespace Reactivity.Types
{
	public class RefDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		private RDictionary<TKey, TValue> _rDictionary;

		public RefDictionary()
		{
		}

		public RefDictionary(Dictionary<TKey, TValue> dictionary)
		{
		}

		public void SetRef(RDictionary<TKey, TValue> rDictionary)
		{
		}

		public new void Add(TKey key, TValue value)
		{
		}

		public new bool Remove(TKey key)
		{
			return false;
		}

		public new void Clear()
		{
		}
	}
}
