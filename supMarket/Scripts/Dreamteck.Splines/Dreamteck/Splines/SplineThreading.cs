using System.Collections.Generic;
using System.Threading;

namespace Dreamteck.Splines
{
	public static class SplineThreading
	{
		public delegate void EmptyHandler();

		internal class ThreadDef
		{
			internal class Worker
			{
				internal bool computing;

				internal Queue<EmptyHandler> instructions;
			}

			internal delegate void BoolHandler(bool flag);

			private ParameterizedThreadStart start;

			internal Thread thread;

			private Worker worker;

			internal bool isAlive => false;

			internal bool computing => false;

			internal ThreadDef()
			{
			}

			internal void Queue(EmptyHandler handler)
			{
			}

			internal void Interrupt()
			{
			}

			internal void Restart()
			{
			}

			internal void Abort()
			{
			}
		}

		internal static ThreadDef[] threads;

		internal static readonly object locker;

		public static int threadCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		static SplineThreading()
		{
		}

		private static void Quitting()
		{
		}

		private static void RunThread(object o)
		{
		}

		public static void Run(EmptyHandler handler)
		{
		}

		public static void PrewarmThreads()
		{
		}

		public static void Stop()
		{
		}
	}
}
