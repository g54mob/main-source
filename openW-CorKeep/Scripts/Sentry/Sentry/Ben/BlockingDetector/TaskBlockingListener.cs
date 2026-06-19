using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;
using System.Threading;

namespace Sentry.Ben.BlockingDetector
{
	internal class TaskBlockingListener : EventListener
	{
		internal static readonly Guid s_tplGuid = new Guid("2e5dba47-a3d2-4d16-8ee0-6671ffdcd7b5");

		private readonly IBlockingMonitor _monitor;

		private readonly ITaskBlockingListenerState _state;

		private static Lazy<StaticTaskBlockingListenerState> LazyDefaultState => new Lazy<StaticTaskBlockingListenerState>();

		internal static StaticTaskBlockingListenerState DefaultState => LazyDefaultState.Value;

		public TaskBlockingListener(IBlockingMonitor monitor)
			: this(monitor, null)
		{
		}

		internal TaskBlockingListener(IBlockingMonitor monitor, ITaskBlockingListenerState? state)
		{
			_monitor = monitor;
			_state = state ?? DefaultState;
		}

		protected override void OnEventSourceCreated(EventSource eventSource)
		{
			if (eventSource.Guid == s_tplGuid)
			{
				EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)3L);
			}
		}

		protected override void OnEventWritten(EventWrittenEventArgs eventData)
		{
			if (Thread.CurrentThread.IsThreadPoolThread)
			{
				DoHandleEvent(eventData.EventId, eventData.Payload);
			}
		}

		internal void DoHandleEvent(int eventId, ReadOnlyCollection<object?>? payload)
		{
			IBlockingMonitor blockingMonitor = (_state.IsSuppressed() ? null : _monitor);
			if (eventId == 10 && payload != null && payload.Count > 3 && payload[3] is int num && num == 1)
			{
				blockingMonitor?.BlockingStart(DetectionSource.EventListener);
			}
			else if (eventId == 11)
			{
				blockingMonitor?.BlockingEnd();
			}
		}
	}
}
