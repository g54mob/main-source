using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class Merge<T> : Observable<T>
	{
		private sealed class _Merge : IDisposable
		{
			public Observer<T> observer;

			public SingleAssignmentDisposableCore disposable;

			public readonly object gate;

			private int sourceCount;

			private int completeCount;

			public _Merge(Observer<T> observer)
			{
				this.observer = observer;
				gate = new object();
				sourceCount = -1;
				base._002Ector();
			}

			public void SetSourceCount(int count)
			{
				lock (gate)
				{
					sourceCount = count;
					if (sourceCount == completeCount)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void TryPublishCompleted()
			{
				lock (gate)
				{
					completeCount++;
					if (completeCount == sourceCount)
					{
						observer.OnCompleted();
						Dispose();
					}
				}
			}

			public void Dispose()
			{
				disposable.Dispose();
			}
		}

		private sealed class _MergeObserver : Observer<T>
		{
			public _MergeObserver(_Merge parent)
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
					lock (_003Cparent_003EP.gate)
					{
						_003Cparent_003EP.observer.OnCompleted(result);
						return;
					}
				}
				_003Cparent_003EP.TryPublishCompleted();
			}
		}

		public Merge(IEnumerable<Observable<T>> sources)
		{
			_003Csources_003EP = sources;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_Merge merge = new _Merge(observer);
			DisposableBuilder builder = Disposable.CreateBuilder();
			int num = 0;
			foreach (Observable<T> item in _003Csources_003EP)
			{
				item.Subscribe(new _MergeObserver(merge)).AddTo(ref builder);
				num++;
			}
			merge.disposable.Disposable = builder.Build();
			merge.SetSourceCount(num);
			return merge;
		}
	}
}
