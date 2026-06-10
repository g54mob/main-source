using System;
using System.Diagnostics;
using System.Threading;

namespace Cysharp.Threading.Tasks.Internal
{
	internal sealed class ContinuationQueue
	{
		private readonly PlayerLoopTiming timing;

		private SpinLock gate;

		private bool dequing;

		private int actionListCount;

		private Action[] actionList;

		private int waitingListCount;

		private Action[] waitingList;

		public ContinuationQueue(PlayerLoopTiming timing)
		{
		}

		public void Enqueue(Action continuation)
		{
		}

		public void Run()
		{
		}

		[DebuggerHidden]
		private void RunCore()
		{
		}
	}
}
