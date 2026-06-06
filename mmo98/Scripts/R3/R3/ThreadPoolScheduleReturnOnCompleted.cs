using System;

namespace R3
{
	internal class ThreadPoolScheduleReturnOnCompleted<T> : Observable<T>
	{
		private sealed class _ReturnOnCompleted : IDisposable, IThreadPoolWorkItem
		{
			private bool stop;

			public _ReturnOnCompleted(Result result, Observer<T> observer)
			{
				_003Cresult_003EP = result;
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			public void Execute()
			{
				if (!stop)
				{
					_003Cobserver_003EP.OnCompleted(_003Cresult_003EP);
				}
			}

			public void Dispose()
			{
				stop = true;
			}
		}

		public ThreadPoolScheduleReturnOnCompleted(Result result)
		{
			_003Cresult_003EP = result;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_ReturnOnCompleted callBack = new _ReturnOnCompleted(_003Cresult_003EP, observer);
			ThreadPool.UnsafeQueueUserWorkItem(callBack, preferLocal: false);
			return callBack;
		}
	}
}
