using System.Collections.Generic;

namespace Coffee.UISoftMaskInternal
{
	internal static class ListPool<T>
	{
		private static readonly ObjectPool<List<T>> s_ListPool = new ObjectPool<List<T>>(() => new List<T>(), (List<T> _) => true, delegate(List<T> x)
		{
			x.Clear();
		});

		public static List<T> Rent()
		{
			return s_ListPool.Rent();
		}

		public static void Return(ref List<T> toRelease)
		{
			s_ListPool.Return(ref toRelease);
		}
	}
}
