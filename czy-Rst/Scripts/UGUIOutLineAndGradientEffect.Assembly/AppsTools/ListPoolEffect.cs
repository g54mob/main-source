using System.Collections.Generic;

namespace AppsTools
{
	public static class ListPoolEffect<T>
	{
		private static readonly ObjectPool<List<T>> pl = new ObjectPool<List<T>>(null, delegate(List<T> l)
		{
			l.Clear();
		});

		public static List<T> Get()
		{
			return pl.Get();
		}

		public static void Release(List<T> r)
		{
			pl.Release(r);
		}
	}
}
