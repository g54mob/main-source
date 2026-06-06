using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal class ReturnOnCompleted<T> : Observable<T>
	{
		private sealed class _ReturnOnCompleted : IDisposable
		{
			public static readonly TimerCallback timerCallback = NextTick;

			private readonly Result result;

			private readonly Observer<T> observer;

			public ITimer? Timer { get; set; }

			public _ReturnOnCompleted(Result result, Observer<T> observer)
			{
				this.result = result;
				this.observer = observer;
				base._002Ector();
			}

			private static void NextTick(object? state)
			{
				_ReturnOnCompleted returnOnCompleted = (_ReturnOnCompleted)state;
				try
				{
					returnOnCompleted.observer.OnCompleted(returnOnCompleted.result);
				}
				finally
				{
					returnOnCompleted.Dispose();
				}
			}

			public void Dispose()
			{
				Timer?.Dispose();
				Timer = null;
			}
		}

		public ReturnOnCompleted(Result complete, TimeSpan dueTime, TimeProvider timeProvider)
		{
			_003Ccomplete_003EP = complete;
			_003CdueTime_003EP = dueTime;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_ReturnOnCompleted returnOnCompleted = new _ReturnOnCompleted(_003Ccomplete_003EP, observer);
			returnOnCompleted.Timer = _003CtimeProvider_003EP.CreateStoppedTimer(_ReturnOnCompleted.timerCallback, returnOnCompleted);
			returnOnCompleted.Timer.InvokeOnce(_003CdueTime_003EP);
			return returnOnCompleted;
		}
	}
}
