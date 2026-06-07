using System.Collections.Generic;

namespace Coffee.UIParticleInternal
{
	internal static class InternalListPool<T>
	{
		public static List<T> Rent()
		{
			return null;
		}

		public static void Return(ref List<T> toRelease)
		{
		}
	}
}
