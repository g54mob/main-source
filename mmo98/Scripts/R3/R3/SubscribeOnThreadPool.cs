using System;

namespace R3
{
	internal sealed class SubscribeOnThreadPool<T> : Observable<T>
	{
		private sealed class _SubscribeOn : Observer<T>, IThreadPoolWorkItem
		{
			private readonly Observer<T> observer;

			private readonly Observable<T> source;

			private SingleAssignmentDisposableCore disposable;

			public _SubscribeOn(Observer<T> observer, Observable<T> source)
			{
				this.observer = observer;
				this.source = source;
			}

			public IDisposable Run()
			{
				ThreadPool.UnsafeQueueUserWorkItem(this, preferLocal: false);
				return this;
			}

			public void Execute()
			{
				try
				{
					disposable.Disposable = source.Subscribe(this);
				}
				catch (Exception obj)
				{
					ObservableSystem.GetUnhandledExceptionHandler()(obj);
					Dispose();
				}
			}

			protected override void OnNextCore(T value)
			{
				observer.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				observer.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				disposable.Dispose();
			}
		}

		public SubscribeOnThreadPool(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _SubscribeOn(observer, _003Csource_003EP).Run();
		}
	}
}
