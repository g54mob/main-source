using System;

namespace PG
{
	public static class ActionExtentions
	{
		public static void SafeInvoke(this Action action)
		{
		}

		public static void SafeInvoke<P>(this Action<P> action, P p)
		{
		}

		public static void SafeInvoke<P1, P2>(this Action<P1, P2> action, P1 p1, P2 p2)
		{
		}
	}
}
