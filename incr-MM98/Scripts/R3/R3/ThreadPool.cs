using System.Threading;

namespace R3
{
	public static class ThreadPool
	{
		private static readonly WaitCallback waitCallback = Execute;

		public static bool UnsafeQueueUserWorkItem(IThreadPoolWorkItem callBack, bool preferLocal)
		{
			return System.Threading.ThreadPool.UnsafeQueueUserWorkItem(waitCallback, callBack);
		}

		private static void Execute(object? state)
		{
			((IThreadPoolWorkItem)state).Execute();
		}
	}
}
