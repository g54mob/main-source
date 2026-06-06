using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class ThrottleLastAsyncSampler<T> : Observable<T>
	{
		private sealed class _ThrottleLast : Observer<T>
		{
			private readonly object gate;

			private readonly CancellationTokenSource cancellationTokenSource;

			private T? lastValue;

			private bool isRunning;

			public _ThrottleLast(Observer<T> observer, Func<T, CancellationToken, ValueTask> sampler, bool configureAwait)
			{
				_003Cobserver_003EP = observer;
				_003Csampler_003EP = sampler;
				_003CconfigureAwait_003EP = configureAwait;
				gate = new object();
				cancellationTokenSource = new CancellationTokenSource();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					lastValue = value;
					if (!isRunning)
					{
						isRunning = true;
						RaiseOnNextAsync(value);
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				cancellationTokenSource.Cancel();
				_003Cobserver_003EP.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				cancellationTokenSource.Cancel();
			}

			private async void RaiseOnNextAsync(T value)
			{
				try
				{
					await _003Csampler_003EP(value, cancellationTokenSource.Token).ConfigureAwait(_003CconfigureAwait_003EP);
				}
				catch (Exception ex)
				{
					if (!(ex is OperationCanceledException ex2) || !(ex2.CancellationToken == cancellationTokenSource.Token))
					{
						OnErrorResume(ex);
					}
				}
				finally
				{
					lock (gate)
					{
						_003Cobserver_003EP.OnNext(lastValue);
						lastValue = default(T);
						isRunning = false;
					}
				}
			}
		}

		public ThrottleLastAsyncSampler(Observable<T> source, Func<T, CancellationToken, ValueTask> sampler, bool configureAwait)
		{
			_003Csource_003EP = source;
			_003Csampler_003EP = sampler;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleLast(observer, _003Csampler_003EP, _003CconfigureAwait_003EP));
		}
	}
}
