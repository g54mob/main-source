using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	public static class ListPool<T>
	{
		private static ObjectPool<List<T>> s_listObjectPool;

		public static List<T> Get()
		{
			return null;
		}

		public static void Release(List<T> obj)
		{
		}

		private static void EnsureInitialized()
		{
		}

		private static List<T> OnCreateItem()
		{
			return null;
		}

		private static void OnReleaseItem(List<T> item)
		{
		}
	}
}
