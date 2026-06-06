using System;
using System.Threading;

namespace ObservableCollections
{
	public class SynchronizationContextCollectionEventDispatcher : ICollectionEventDispatcher
	{
		private static readonly Lazy<ICollectionEventDispatcher> current = new Lazy<ICollectionEventDispatcher>(() => new SynchronizationContextCollectionEventDispatcher(SynchronizationContext.Current ?? throw new InvalidOperationException("SynchronizationContext.Current is null")));

		public static readonly ICollectionEventDispatcher Current = current.Value;

		private readonly SynchronizationContext synchronizationContext;

		private static readonly SendOrPostCallback callback = SendOrPostCallback;

		public SynchronizationContextCollectionEventDispatcher(SynchronizationContext synchronizationContext)
		{
			this.synchronizationContext = synchronizationContext;
		}

		public void Post(CollectionEventDispatcherEventArgs ev)
		{
			if (SynchronizationContext.Current == null)
			{
				synchronizationContext.Post(callback, ev);
			}
			else
			{
				callback(ev);
			}
		}

		private static void SendOrPostCallback(object? state)
		{
			((CollectionEventDispatcherEventArgs)state).Invoke();
		}
	}
}
