using System;

namespace R3
{
	internal sealed class MergeMany<T> : Observable<T>
	{
		private sealed class _MergeMany : Observer<Observable<T>>
		{
			private sealed class MergeInner : Observer<T>
			{
				public MergeInner(_MergeMany parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					lock (_003Cparent_003EP.gate)
					{
						_003Cparent_003EP.observer.OnNext(value);
					}
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					lock (_003Cparent_003EP.gate)
					{
						_003Cparent_003EP.observer.OnErrorResume(error);
					}
				}

				protected override void OnCompletedCore(Result result)
				{
					lock (_003Cparent_003EP.gate)
					{
						if (result.IsFailure)
						{
							_003Cparent_003EP.observer.OnCompleted(result);
							return;
						}
						_MergeMany mergeMany = _003Cparent_003EP;
						if (mergeMany != null && mergeMany.isStopped)
						{
							CompositeDisposable subscriptions = mergeMany.subscriptions;
							if (subscriptions != null && subscriptions.Count == 1)
							{
								_003Cparent_003EP.PublishCompleted(result);
							}
						}
					}
				}

				protected override void DisposeCore()
				{
					_003Cparent_003EP.subscriptions.Remove(this);
				}
			}

			private readonly Observer<T> observer;

			private readonly object gate;

			private readonly CompositeDisposable subscriptions;

			private bool isStopped;

			protected override bool AutoDisposeOnCompleted => false;

			public _MergeMany(Observer<T> observer)
			{
				this.observer = observer;
				gate = new object();
				subscriptions = new CompositeDisposable();
				base._002Ector();
			}

			protected override void OnNextCore(Observable<T> value)
			{
				MergeInner item = new MergeInner(this);
				lock (gate)
				{
					subscriptions.Add(item);
				}
				value.Subscribe(item);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (gate)
				{
					observer.OnErrorResume(error);
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (gate)
				{
					if (result.IsFailure)
					{
						PublishCompleted(result);
						return;
					}
					isStopped = true;
					if (subscriptions.Count <= 0)
					{
						PublishCompleted(result);
					}
				}
			}

			protected override void DisposeCore()
			{
				subscriptions.Dispose();
			}

			private void PublishCompleted(Result result)
			{
				try
				{
					lock (gate)
					{
						observer.OnCompleted(result);
					}
				}
				finally
				{
					Dispose();
				}
			}
		}

		public MergeMany(Observable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csources_003EP.Subscribe(new _MergeMany(observer));
		}
	}
}
