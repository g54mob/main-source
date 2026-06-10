using System;
using System.Diagnostics;

namespace Cysharp.Threading.Tasks.Internal
{
	internal sealed class PlayerLoopRunner
	{
		private readonly PlayerLoopTiming timing;

		private readonly object runningAndQueueLock;

		private readonly object arrayLock;

		private readonly Action<Exception> unhandledExceptionCallback;

		private int tail;

		private bool running;

		private IPlayerLoopItem[] loopItems;

		private MinimumQueue<IPlayerLoopItem> waitQueue;

		public PlayerLoopRunner(PlayerLoopTiming timing)
		{
		}

		public void AddAction(IPlayerLoopItem item)
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
