using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class Return<T> : Observable<T>
	{
		private sealed class _Return : IDisposable
		{
			public static readonly TimerCallback timerCallback = NextTick;

			internal CancellationTokenRegistration cancellationTokenRegistration;

			private readonly T value;

			private readonly Observer<T> observer;

			public ITimer? Timer { get; set; }

			public _Return(T value, Observer<T> observer)
			{
				this.value = value;
				this.observer = observer;
				base._002Ector();
			}

			private static void NextTick(object? state)
			{
				_Return obj = (_Return)state;
				obj.observer.OnNext(obj.value);
				obj.observer.OnCompleted();
			}

			public void CompleteDispose()
			{
				observer.OnCompleted();
				Dispose();
			}

			public void Dispose()
			{
				cancellationTokenRegistration.Dispose();
				Timer?.Dispose();
				Timer = null;
			}
		}

		public Return(T value, TimeSpan dueTime, TimeProvider timeProvider, CancellationToken cancellationToken)
		{
			_003Cvalue_003EP = value;
			_003CdueTime_003EP = dueTime;
			_003CtimeProvider_003EP = timeProvider;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_Return obj = new _Return(_003Cvalue_003EP, observer);
			obj.Timer = _003CtimeProvider_003EP.CreateStoppedTimer(_Return.timerCallback, obj);
			if (_003CcancellationToken_003EP.CanBeCanceled)
			{
				obj.cancellationTokenRegistration = _003CcancellationToken_003EP.UnsafeRegister(delegate(object? state)
				{
					((_Return)state).CompleteDispose();
				}, obj);
			}
			obj.Timer.InvokeOnce(_003CdueTime_003EP);
			return obj;
		}
	}
}
