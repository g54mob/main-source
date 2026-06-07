using System;

namespace R3
{
	internal sealed class NotSupportedFrameProvider : FrameProvider
	{
		public override long GetFrameCount()
		{
			throw new NotSupportedException("ObservableSystem.DefaultFrameProvider is not set. Please set ObservableSystem.DefaultFrameProvider to a valid FrameProvider(ThreadSleepFrameProvider, etc...).");
		}

		public override void Register(IFrameRunnerWorkItem callback)
		{
			throw new NotSupportedException("ObservableSystem.DefaultFrameProvider is not set. Please set ObservableSystem.DefaultFrameProvider to a valid FrameProvider(ThreadSleepFrameProvider, etc...).");
		}
	}
}
