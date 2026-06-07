using System.Collections.Generic;

namespace Coffee.UIParticleInternal
{
	internal static class ListPool<T>
	{
		private static readonly ObjectPool<List<T>> s_ListPool;

		public static List<T> Rent()
		{
			return null;
		}

		public static void Return(ref List<T> toRelease)
		{
		}
	}
}
