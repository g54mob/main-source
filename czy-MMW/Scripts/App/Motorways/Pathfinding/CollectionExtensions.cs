using System.Collections.Generic;

namespace Motorways.Pathfinding
{
	public static class CollectionExtensions
	{
		public static V GetOrCreate<K, V>(this IDictionary<K, V> collection, K key) where V : new()
		{
			if (!collection.TryGetValue(key, out var value))
			{
				value = (collection[key] = new V());
			}
			return value;
		}
	}
}
