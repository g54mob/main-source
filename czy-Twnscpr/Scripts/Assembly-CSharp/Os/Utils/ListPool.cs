using System.Collections.Generic;

namespace Os.Utils
{
	public static class ListPool<T>
	{
		private static List<List<T>> pool;

		public static List<T> Get()
		{
			return null;
		}

		public static List<T> Get(int capacity)
		{
			return null;
		}

		public static void Return(ref List<T> list)
		{
		}
	}
}
