using System;

namespace R3
{
	internal sealed class IndexObservable : Observable<int>
	{
		private sealed class _Index : Observer<Unit>
		{
			private int index;

			public _Index(Observer<int> observer)
			{
				_003Cobserver_003EP = observer;
				index = -1;
				base._002Ector();
			}

			protected override void OnNextCore(Unit value)
			{
				checked
				{
					index++;
					_003Cobserver_003EP.OnNext(index);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public IndexObservable(Observable<Unit> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<int> observer)
		{
			return _003Csource_003EP.Subscribe(new _Index(observer));
		}
	}
	internal sealed class IndexObservable<T> : Observable<(int Index, T Item)>
	{
		private sealed class _Index : Observer<T>
		{
			private int index;

			public _Index(Observer<(int Index, T Item)> observer)
			{
				_003Cobserver_003EP = observer;
				index = -1;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				checked
				{
					index++;
					_003Cobserver_003EP.OnNext((index, value));
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public IndexObservable(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(int Index, T Item)> observer)
		{
			return _003Csource_003EP.Subscribe(new _Index(observer));
		}
	}
}
