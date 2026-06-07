using System;

namespace UI.Utilities
{
	public static class EventExtensions
	{
		public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

		public static void Trigger(this Action action)
		{
		}

		public static void Trigger<T>(this Action<T> action, T v)
		{
		}

		public static void Trigger<T1, T2>(this Action<T1, T2> action, T1 v1, T2 v2)
		{
		}

		public static void Trigger<T1, T2, T3>(this Action<T1, T2, T3> action, T1 v1, T2 v2, T3 v3)
		{
		}

		public static void Trigger<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 v1, T2 v2, T3 v3, T4 v4)
		{
		}

		public static void Trigger<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action, T1 v1, T2 v2, T3 v3, T4 v4, T5 v5)
		{
		}
	}
}
