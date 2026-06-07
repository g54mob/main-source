using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class DebounceSelector<T> : Observable<T>
	{
		private sealed class _Debounce : Observer<T>
		{
			private readonly object gate;

			private T? latestValue;

			private bool hasValue;

			private bool isRunning;

			private int taskId;

			private CancellationTokenSource cancellationTokenSource;

			public _Debounce(Observer<T> observer, Func<T, CancellationToken, ValueTask> throttleDurationSelector, bool configureAwait)
			{
				_003Cobserver_003EP = observer;
				_003CthrottleDurationSelector_003EP = throttleDurationSelector;
				_003CconfigureAwait_003EP = configureAwait;
				gate = new object();
				cancellationTokenSource = new CancellationTokenSource();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					latestValue = value;
					hasValue = true;
					if (isRunning)
					{
						cancellationTokenSource.Cancel();
						cancellationTokenSource = new CancellationTokenSource();
					}
					int num = taskId + 1;
					Volatile.Write(ref taskId, num);
					isRunning = true;
					PublishOnNextAfterAsync(value, num, cancellationTokenSource.Token);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (gate)
				{
					_003Cobserver_003EP.OnErrorResume(error);
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (gate)
				{
					cancellationTokenSource.Cancel();
					if (hasValue)
					{
						_003Cobserver_003EP.OnNext(latestValue);
						hasValue = false;
						latestValue = default(T);
					}
					_003Cobserver_003EP.OnCompleted(result);
				}
			}

			protected override void DisposeCore()
			{
				cancellationTokenSource.Cancel();
			}

			private async void PublishOnNextAfterAsync(T value, int id, CancellationToken cancellationToken)
			{
				try
				{
					await _003CthrottleDurationSelector_003EP(value, cancellationToken).ConfigureAwait(_003CconfigureAwait_003EP);
				}
				catch (Exception ex)
				{
					if (!(ex is OperationCanceledException ex2) || !(ex2.CancellationToken == cancellationToken))
					{
						OnErrorResume(ex);
					}
				}
				finally
				{
					lock (gate)
					{
						if (taskId == id && hasValue)
						{
							_003Cobserver_003EP.OnNext(latestValue);
							hasValue = false;
							latestValue = default(T);
							isRunning = false;
						}
					}
				}
			}
		}

		public DebounceSelector(Observable<T> source, Func<T, CancellationToken, ValueTask> throttleDurationSelector, bool configureAwait)
		{
			_003Csource_003EP = source;
			_003CthrottleDurationSelector_003EP = throttleDurationSelector;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Debounce(observer, _003CthrottleDurationSelector_003EP, _003CconfigureAwait_003EP));
		}
	}
}
