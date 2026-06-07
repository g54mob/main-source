using System;

namespace R3
{
	internal sealed class Switch<T> : Observable<T>
	{
		private sealed class _Switch : Observer<Observable<T>>
		{
			public Observer<T> observer;

			public readonly object gate;

			private SerialDisposableCore subscription;

			public ulong id;

			public bool runningInner;

			public bool stoppedOuter;

			protected override bool AutoDisposeOnCompleted => false;

			public _Switch(Observer<T> observer)
			{
				this.observer = observer;
				gate = new object();
				base._002Ector();
			}

			protected override void OnNextCore(Observable<T> value)
			{
				ulong num = 0uL;
				lock (gate)
				{
					num = ++id;
					runningInner = true;
				}
				SwitchObserver disposable = new SwitchObserver(this, num);
				subscription.Disposable = disposable;
				value.Subscribe(disposable);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (gate)
				{
					if (result.IsFailure)
					{
						try
						{
							observer.OnCompleted(result);
							return;
						}
						finally
						{
							Dispose();
						}
					}
					stoppedOuter = true;
					if (!runningInner)
					{
						try
						{
							observer.OnCompleted();
							return;
						}
						finally
						{
							Dispose();
						}
					}
				}
			}

			protected override void DisposeCore()
			{
				subscription.Dispose();
			}
		}

		private sealed class SwitchObserver : Observer<T>
		{
			public SwitchObserver(_Switch parent, ulong id)
			{
				_003Cparent_003EP = parent;
				_003Cid_003EP = id;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				lock (_003Cparent_003EP.gate)
				{
					if (_003Cparent_003EP.id == _003Cid_003EP)
					{
						_003Cparent_003EP.observer.OnNext(value);
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (_003Cparent_003EP.gate)
				{
					if (_003Cparent_003EP.id == _003Cid_003EP)
					{
						_003Cparent_003EP.observer.OnErrorResume(error);
					}
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (_003Cparent_003EP.gate)
				{
					if (_003Cparent_003EP.id != _003Cid_003EP)
					{
						return;
					}
					if (result.IsFailure)
					{
						_003Cparent_003EP.observer.OnCompleted(result);
						return;
					}
					_003Cparent_003EP.runningInner = false;
					if (_003Cparent_003EP.stoppedOuter)
					{
						_003Cparent_003EP.observer.OnCompleted(result);
					}
				}
			}
		}

		public Switch(Observable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csources_003EP.Subscribe(new _Switch(observer));
		}
	}
}
