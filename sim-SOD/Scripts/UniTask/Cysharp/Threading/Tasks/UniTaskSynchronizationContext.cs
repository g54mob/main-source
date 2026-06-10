using System.Runtime.InteropServices;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	public class UniTaskSynchronizationContext : SynchronizationContext
	{
		[StructLayout((LayoutKind)3)]
		private readonly struct Callback
		{
			private readonly SendOrPostCallback callback;

			private readonly object state;

			public void Invoke()
			{
			}
		}

		private static SpinLock gate;

		private static bool dequing;

		private static int actionListCount;

		private static Callback[] actionList;

		private static int waitingListCount;

		private static Callback[] waitingList;

		internal static void Run()
		{
		}
	}
}
