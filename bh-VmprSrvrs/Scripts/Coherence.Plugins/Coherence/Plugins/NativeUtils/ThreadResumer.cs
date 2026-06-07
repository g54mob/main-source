using System.Collections.Generic;
using System.Threading;
using Coherence.Log;

namespace Coherence.Plugins.NativeUtils
{
	public class ThreadResumer
	{
		private readonly int rsProcessId;

		private readonly CancellationToken cancellationToken;

		private readonly ThreadResumerSettings settings;

		private readonly Thread thread;

		private readonly HashSet<ulong> suspendedThreads;

		private readonly ulong[] threadsBuffer;

		private readonly Logger logger;

		public ThreadResumer(int rsProcessId, CancellationToken cancellationToken, ThreadResumerSettings settings)
		{
		}

		private void Run()
		{
		}

		internal int FindAndResumeSuspendedThreads()
		{
			return 0;
		}
	}
}
