using System.Collections.Generic;

namespace Coffee.UIEffectInternal
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
