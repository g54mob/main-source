using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class SkipUntilAsync<T> : Observable<T>
	{
		private sealed class _SkipUntil : Observer<T>, IDisposable
		{
			private readonly CancellationTokenSource cancellationTokenSource;

			private int isTaskRunning;

			private bool open;

			public _SkipUntil(Observer<T> observer, Func<T, CancellationToken, ValueTask> asyncFunc, bool configureAwait)
			{
				_003Cobserver_003EP = observer;
				_003CasyncFunc_003EP = asyncFunc;
				_003CconfigureAwait_003EP = configureAwait;
				cancellationTokenSource = new CancellationTokenSource();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (Interlocked.Exchange(ref isTaskRunning, 1) == 0)
				{
					TaskStart(value);
				}
				if (Volatile.Read(ref open))
				{
					_003Cobserver_003EP.OnNext(value);
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

			private async void TaskStart(T value)
			{
				try
				{
					await _003CasyncFunc_003EP(value, cancellationTokenSource.Token).ConfigureAwait(_003CconfigureAwait_003EP);
				}
				catch (Exception ex)
				{
					if (!(ex is OperationCanceledException ex2) || !(ex2.CancellationToken == cancellationTokenSource.Token))
					{
						_003Cobserver_003EP.OnCompleted(Result.Failure(ex));
					}
					return;
				}
				Volatile.Write(ref open, value: true);
			}
		}

		public SkipUntilAsync(Observable<T> source, Func<T, CancellationToken, ValueTask> asyncFunc, bool configureAwait)
		{
			_003Csource_003EP = source;
			_003CasyncFunc_003EP = asyncFunc;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipUntil(observer, _003CasyncFunc_003EP, _003CconfigureAwait_003EP));
		}
	}
}
