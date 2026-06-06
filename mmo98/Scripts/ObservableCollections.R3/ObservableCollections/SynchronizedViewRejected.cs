using System;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewRejected<T, TView> : Observable<RejectedViewChangedEvent>
	{
		private sealed class _SynchronizedViewRejected : IDisposable
		{
			private readonly ISynchronizedView<T, TView> source;

			private readonly Observer<RejectedViewChangedEvent> observer;

			private readonly CancellationTokenRegistration cancellationTokenRegistration;

			private readonly Action<RejectedViewChangedAction, int, int> handlerDelegate;

			public _SynchronizedViewRejected(ISynchronizedView<T, TView> source, Observer<RejectedViewChangedEvent> observer, CancellationToken cancellationToken)
			{
				this.source = source;
				this.observer = observer;
				handlerDelegate = Handler;
				source.RejectedViewChanged += handlerDelegate;
				if (cancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
					{
						_SynchronizedViewRejected obj = (_SynchronizedViewRejected)state;
						obj.observer.OnCompleted();
						obj.Dispose();
					}, this);
				}
			}

			public void Dispose()
			{
				source.RejectedViewChanged -= handlerDelegate;
				cancellationTokenRegistration.Dispose();
			}

			private void Handler(RejectedViewChangedAction rejectedViewChangedAction, int newIndex, int oldIndex)
			{
				observer.OnNext(new RejectedViewChangedEvent(rejectedViewChangedAction, newIndex, oldIndex));
			}
		}

		public SynchronizedViewRejected(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<RejectedViewChangedEvent> observer)
		{
			return new _SynchronizedViewRejected(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
