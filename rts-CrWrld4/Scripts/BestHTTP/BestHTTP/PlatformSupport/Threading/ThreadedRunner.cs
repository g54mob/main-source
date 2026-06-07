using System;

namespace BestHTTP.PlatformSupport.Threading
{
	public static class ThreadedRunner
	{
		public static void RunShortLiving<T>(Action<T> job, T param)
		{
		}

		public static void RunShortLiving<T1, T2>(Action<T1, T2> job, T1 param1, T2 param2)
		{
		}

		public static void RunShortLiving<T1, T2, T3>(Action<T1, T2, T3> job, T1 param1, T2 param2, T3 param3)
		{
		}

		public static void RunShortLiving<T1, T2, T3, T4>(Action<T1, T2, T3, T4> job, T1 param1, T2 param2, T3 param3, T4 param4)
		{
		}

		public static void RunShortLiving(Action job)
		{
		}

		public static void RunLongLiving(Action job)
		{
		}
	}
}
