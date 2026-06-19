using System;
using System.Threading;

namespace Sentry.Ben.BlockingDetector
{
	public class SuppressBlockingDetection : IDisposable
	{
		internal readonly ITaskBlockingListenerState _listener;

		internal readonly DetectBlockingSynchronizationContext? _context;

		public SuppressBlockingDetection()
			: this(SynchronizationContext.Current as DetectBlockingSynchronizationContext, TaskBlockingListener.DefaultState)
		{
		}

		internal SuppressBlockingDetection(DetectBlockingSynchronizationContext? context, ITaskBlockingListenerState listener)
		{
			_context = context;
			_listener = listener;
			_context?.Suppress();
			_listener.Suppress();
		}

		public void Dispose()
		{
			_listener.Restore();
			_context?.Restore();
		}
	}
}
