using System;
using System.Threading;
using R3.Collections;

namespace R3
{
	internal sealed class ObserveOnSynchronizationContext<T> : Observable<T>
	{
		private sealed class _ObserveOn : Observer<T>
		{
			private static readonly SendOrPostCallback postCallback = DrainMessages;

			private readonly Observer<T> observer;

			private readonly SynchronizationContext synchronizationContext;

			private readonly object gate = new object();

			private SwapListCore<Notification<T>> list;

			private bool running;

			protected override bool AutoDisposeOnCompleted => false;

			public _ObserveOn(Observer<T> observer, SynchronizationContext synchronizationContext)
			{
				this.observer = observer;
				this.synchronizationContext = synchronizationContext;
			}

			protected override void OnNextCore(T value)
			{
				EnqueueValue(new Notification<T>(value));
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				EnqueueValue(new Notification<T>(error));
			}

			protected override void OnCompletedCore(Result result)
			{
				EnqueueValue(new Notification<T>(result));
			}

			private void EnqueueValue(Notification<T> value)
			{
				lock (gate)
				{
					if (!base.IsDisposed)
					{
						list.Add(value);
						if (!running)
						{
							running = true;
							synchronizationContext.Post(postCallback, this);
						}
					}
				}
			}

			protected override void DisposeCore()
			{
				lock (gate)
				{
					list.Dispose();
				}
			}

			private static void DrainMessages(object? state)
			{
				_ObserveOn observeOn = (_ObserveOn)state;
				ReadOnlySpan<Notification<T>> readOnlySpan;
				bool token;
				lock (observeOn.gate)
				{
					readOnlySpan = observeOn.list.Swap(out token);
					if (readOnlySpan.Length == 0)
					{
						goto IL_00ea;
					}
				}
				ReadOnlySpan<Notification<T>> readOnlySpan2 = readOnlySpan;
				for (int i = 0; i < readOnlySpan2.Length; i++)
				{
					Notification<T> notification = readOnlySpan2[i];
					try
					{
						switch (notification.Kind)
						{
						case NotificationKind.OnNext:
							observeOn.observer.OnNext(notification.Value);
							break;
						case NotificationKind.OnErrorResume:
							observeOn.observer.OnErrorResume(notification.Error);
							break;
						case NotificationKind.OnCompleted:
							try
							{
								observeOn.observer.OnCompleted(notification.Result);
							}
							finally
							{
								observeOn.Dispose();
							}
							break;
						}
					}
					catch (Exception obj)
					{
						try
						{
							ObservableSystem.GetUnhandledExceptionHandler()(obj);
						}
						catch
						{
						}
					}
				}
				goto IL_00ea;
				IL_00ea:
				lock (observeOn.gate)
				{
					observeOn.list.Clear(token);
					if (observeOn.IsDisposed)
					{
						observeOn.running = false;
					}
					else if (observeOn.list.HasValue)
					{
						observeOn.synchronizationContext.Post(postCallback, observeOn);
					}
					else
					{
						observeOn.running = false;
					}
				}
			}
		}

		public ObserveOnSynchronizationContext(Observable<T> source, SynchronizationContext synchronizationContext)
		{
			_003Csource_003EP = source;
			_003CsynchronizationContext_003EP = synchronizationContext;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ObserveOn(observer, _003CsynchronizationContext_003EP));
		}
	}
}
