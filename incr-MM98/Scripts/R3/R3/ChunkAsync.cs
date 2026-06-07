using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class ChunkAsync<T> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>
		{
			private readonly List<T> list;

			private CancellationTokenSource cancellationTokenSource;

			private bool isRunning;

			public _Chunk(Observer<T[]> observer, Func<T, CancellationToken, ValueTask> asyncWindow, bool configureAwait)
			{
				_003Cobserver_003EP = observer;
				_003CasyncWindow_003EP = asyncWindow;
				_003CconfigureAwait_003EP = configureAwait;
				list = new List<T>();
				cancellationTokenSource = new CancellationTokenSource();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				lock (list)
				{
					list.Add(value);
					if (!isRunning)
					{
						isRunning = true;
						StartWindow(value);
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
				lock (list)
				{
					if (list.Count > 0)
					{
						_003Cobserver_003EP.OnNext(list.ToArray());
						list.Clear();
					}
				}
				_003Cobserver_003EP.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				cancellationTokenSource.Cancel();
			}

			private async void StartWindow(T value)
			{
				try
				{
					await _003CasyncWindow_003EP(value, cancellationTokenSource.Token).ConfigureAwait(_003CconfigureAwait_003EP);
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
					lock (list)
					{
						_003Cobserver_003EP.OnNext(list.ToArray());
						list.Clear();
						isRunning = false;
					}
				}
			}
		}

		public ChunkAsync(Observable<T> source, Func<T, CancellationToken, ValueTask> asyncWindow, bool configureAwait)
		{
			_003Csource_003EP = source;
			_003CasyncWindow_003EP = asyncWindow;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _Chunk(observer, _003CasyncWindow_003EP, _003CconfigureAwait_003EP));
		}
	}
}
