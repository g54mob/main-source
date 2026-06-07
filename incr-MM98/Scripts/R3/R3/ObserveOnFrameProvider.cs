using System;
using R3.Collections;

namespace R3
{
	internal sealed class ObserveOnFrameProvider<T> : Observable<T>
	{
		internal sealed class _ObserveOn : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly FrameProvider frameProvider;

			private readonly object gate = new object();

			private SwapListCore<Notification<T>> list;

			private bool running;

			protected override bool AutoDisposeOnCompleted => false;

			public _ObserveOn(Observer<T> observer, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.frameProvider = frameProvider;
				running = false;
				list = default(SwapListCore<Notification<T>>);
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
							frameProvider.Register(this);
						}
					}
				}
			}

			public bool MoveNext(long frameCount)
			{
				ReadOnlySpan<Notification<T>> readOnlySpan;
				bool token;
				lock (gate)
				{
					readOnlySpan = list.Swap(out token);
					if (readOnlySpan.Length == 0)
					{
						goto IL_00e1;
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
							observer.OnNext(notification.Value);
							break;
						case NotificationKind.OnErrorResume:
							observer.OnErrorResume(notification.Error);
							break;
						case NotificationKind.OnCompleted:
							try
							{
								observer.OnCompleted(notification.Result);
							}
							finally
							{
								Dispose();
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
				goto IL_00e1;
				IL_00e1:
				lock (gate)
				{
					list.Clear(token);
					if (base.IsDisposed)
					{
						running = false;
						return false;
					}
					if (list.HasValue)
					{
						return true;
					}
					running = false;
					return false;
				}
			}

			protected override void DisposeCore()
			{
				lock (gate)
				{
					list.Dispose();
				}
			}
		}

		public ObserveOnFrameProvider(Observable<T> source, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ObserveOn(observer, _003CframeProvider_003EP));
		}
	}
}
