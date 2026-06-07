using System;
using System.Threading;

namespace R3
{
	internal sealed class ThreadPoolScheduleReturn<T> : Observable<T>
	{
		private sealed class _Return : IDisposable, IThreadPoolWorkItem
		{
			private bool stop;

			internal CancellationTokenRegistration cancellationTokenRegistration;

			public _Return(T value, Observer<T> observer)
			{
				_003Cvalue_003EP = value;
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			public void Execute()
			{
				if (!stop)
				{
					_003Cobserver_003EP.OnNext(_003Cvalue_003EP);
					_003Cobserver_003EP.OnCompleted();
				}
			}

			public void CompleteDispose()
			{
				_003Cobserver_003EP.OnCompleted();
				Dispose();
			}

			public void Dispose()
			{
				cancellationTokenRegistration.Dispose();
				stop = true;
			}
		}

		public ThreadPoolScheduleReturn(T value, CancellationToken cancellationToken)
		{
			_003Cvalue_003EP = value;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_Return obj = new _Return(_003Cvalue_003EP, observer);
			if (_003CcancellationToken_003EP.CanBeCanceled)
			{
				obj.cancellationTokenRegistration = _003CcancellationToken_003EP.UnsafeRegister(delegate(object? state)
				{
					((_Return)state).CompleteDispose();
				}, obj);
			}
			ThreadPool.UnsafeQueueUserWorkItem(obj, preferLocal: false);
			return obj;
		}
	}
}
