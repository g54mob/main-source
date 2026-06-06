using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class ConcatMany<T> : Observable<T>
	{
		private sealed class _ConcatMany : Observer<Observable<T>>
		{
			private sealed class ConcatInner : Observer<T>
			{
				protected override bool AutoDisposeOnCompleted => false;

				public ConcatInner(_ConcatMany parent)
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
					if (result.IsFailure)
					{
						_003Cparent_003EP.OnCompleted();
						return;
					}
					lock (_003Cparent_003EP.gate)
					{
						if (_003Cparent_003EP.q.Count > 0)
						{
							Observable<T> observable = _003Cparent_003EP.q.Dequeue();
							_003Cparent_003EP.serialDisposable.Disposable = observable.Subscribe(new ConcatInner(_003Cparent_003EP));
							return;
						}
						_003Cparent_003EP.activeCount--;
						_ConcatMany concatMany = _003Cparent_003EP;
						if (concatMany != null && concatMany.isStopped && concatMany.activeCount == 0)
						{
							_003Cparent_003EP.PublishCompleted(result);
						}
					}
				}
			}

			private readonly Observer<T> observer;

			private readonly object gate;

			private readonly Queue<Observable<T>> q;

			private SerialDisposableCore serialDisposable;

			private bool isStopped;

			private int activeCount;

			protected override bool AutoDisposeOnCompleted => false;

			public _ConcatMany(Observer<T> observer)
			{
				this.observer = observer;
				gate = new object();
				q = new Queue<Observable<T>>();
				base._002Ector();
			}

			protected override void OnNextCore(Observable<T> value)
			{
				lock (gate)
				{
					if (activeCount < 1)
					{
						activeCount++;
						serialDisposable.Disposable = value.Subscribe(new ConcatInner(this));
					}
					else
					{
						q.Enqueue(value);
					}
				}
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
				if (result.IsFailure)
				{
					PublishCompleted(result);
					return;
				}
				lock (gate)
				{
					isStopped = true;
					if (activeCount == 0)
					{
						PublishCompleted(result);
					}
				}
			}

			protected override void DisposeCore()
			{
				serialDisposable.Dispose();
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

		public ConcatMany(Observable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csources_003EP.Subscribe(new _ConcatMany(observer));
		}
	}
}
