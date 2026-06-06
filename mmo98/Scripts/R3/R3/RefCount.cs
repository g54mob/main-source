using System;

namespace R3
{
	internal sealed class RefCount<T> : Observable<T>
	{
		private sealed class _RefCount : Observer<T>
		{
			public _RefCount(RefCount<T> parent, Observer<T> observer)
			{
				_003Cparent_003EP = parent;
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				lock (_003Cparent_003EP.gate)
				{
					if (--_003Cparent_003EP.refCount == 0)
					{
						_003Cparent_003EP.connection?.Dispose();
						_003Cparent_003EP.connection = null;
					}
				}
			}
		}

		private readonly object gate;

		private int refCount;

		private IDisposable? connection;

		public RefCount(ConnectableObservable<T> source)
		{
			_003Csource_003EP = source;
			gate = new object();
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			lock (gate)
			{
				this.refCount++;
				bool num = this.refCount == 1;
				_RefCount refCount = new _RefCount(this, observer);
				IDisposable result = _003Csource_003EP.Subscribe(refCount);
				if (num && !refCount.IsDisposed)
				{
					connection = _003Csource_003EP.Connect();
				}
				return result;
			}
		}
	}
}
