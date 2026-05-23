using System.Collections.Generic;

internal static class LocBakeListPool<T>
{
	private static readonly LocBakeObjectPool<List<T>> s_ListPool = new LocBakeObjectPool<List<T>>(null, delegate(List<T> l)
	{
		l.Clear();
	});

	public static List<T> Get()
	{
		return s_ListPool.Get();
	}

	public static void Release(List<T> toRelease)
	{
		s_ListPool.Release(toRelease);
	}
}
