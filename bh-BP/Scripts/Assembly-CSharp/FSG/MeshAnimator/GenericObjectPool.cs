using System.Collections.Generic;

namespace FSG.MeshAnimator
{
	public static class GenericObjectPool<T>
	{
		private static Stack<T> pool;

		public static int Count => 0;

		public static void InitPool(int count)
		{
		}

		public static T Get()
		{
			return default(T);
		}

		public static void Return(T obj)
		{
		}
	}
}
