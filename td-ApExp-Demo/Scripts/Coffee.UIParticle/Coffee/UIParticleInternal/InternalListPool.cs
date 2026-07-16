using System.Collections.Generic;
using UnityEngine.Pool;

namespace Coffee.UIParticleInternal
{
	internal static class InternalListPool<T>
	{
		public static List<T> Rent()
		{
			return CollectionPool<List<T>, T>.Get();
		}

		public static void Return(ref List<T> toRelease)
		{
			if (toRelease != null)
			{
				CollectionPool<List<T>, T>.Release(toRelease);
			}
			toRelease = null;
		}
	}
}
