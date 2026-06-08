using System.Collections.Generic;

namespace KitchenData
{
	public static class LookupHelpers
	{
		public static bool TryGet<T, TKey, TValue>(List<T> list, TKey key, out TValue value) where T : IListLookup<TKey, TValue>
		{
			foreach (T item in list)
			{
				if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
				{
					value = item.Value;
					return true;
				}
			}
			value = default(TValue);
			return false;
		}
	}
}
