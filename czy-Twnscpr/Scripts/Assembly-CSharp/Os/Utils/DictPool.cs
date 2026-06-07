using System.Collections.Generic;

namespace Os.Utils
{
	public static class DictPool<TKey, TValue>
	{
		private static List<Dictionary<TKey, TValue>> pool;

		public static Dictionary<TKey, TValue> Get(int capacity = 4)
		{
			return null;
		}

		public static void Return(ref Dictionary<TKey, TValue> list)
		{
		}
	}
}
