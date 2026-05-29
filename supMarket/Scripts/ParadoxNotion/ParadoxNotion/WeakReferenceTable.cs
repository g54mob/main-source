using System;
using System.Collections.Generic;

namespace ParadoxNotion
{
	public class WeakReferenceTable<TKey, TValue> where TKey : class
	{
		private List<WeakReference<TKey>> keys;

		private List<TValue> values;

		public int Count => 0;

		public void Clear()
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void Remove(TKey key)
		{
		}

		public bool TryGetValueWithRefCheck(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public void RemoveMissingReferences()
		{
		}

		private void CheckCount()
		{
		}
	}
}
