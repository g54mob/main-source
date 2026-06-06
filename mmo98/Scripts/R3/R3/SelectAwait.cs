using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class SelectAwait<T, TResult> : Observable<TResult>
	{
		private sealed class SelectAwaitSequential : AwaitOperationSequentialObserver<T>
		{
			public SelectAwaitSequential(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				TResult value2 = await _003Cselector_003EP(value, cancellationToken).ConfigureAwait(configureAwait);
				_003Cobserver_003EP.OnNext(value2);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void PublishOnCompleted(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		private sealed class SelectAwaitDrop : AwaitOperationDropObserver<T>
		{
			public SelectAwaitDrop(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				TResult value2 = await _003Cselector_003EP(value, cancellationToken).ConfigureAwait(configureAwait);
				_003Cobserver_003EP.OnNext(value2);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void PublishOnCompleted(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		private sealed class SelectAwaitParallel : AwaitOperationParallelObserver<T>
		{
			public SelectAwaitParallel(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				TResult value2 = await _003Cselector_003EP(value, cancellationToken).ConfigureAwait(configureAwait);
				lock (gate)
				{
					_003Cobserver_003EP.OnNext(value2);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (gate)
				{
					_003Cobserver_003EP.OnErrorResume(error);
				}
			}

			protected override void PublishOnCompleted(Result result)
			{
				lock (gate)
				{
					_003Cobserver_003EP.OnCompleted(result);
				}
			}
		}

		private sealed class SelectAwaitSwitch : AwaitOperationSwitchObserver<T>
		{
			public SelectAwaitSwitch(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (gate)
				{
					_003Cobserver_003EP.OnErrorResume(error);
				}
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				TResult value2 = await _003Cselector_003EP(value, cancellationToken).ConfigureAwait(configureAwait);
				lock (gate)
				{
					if (!cancellationToken.IsCancellationRequested)
					{
						_003Cobserver_003EP.OnNext(value2);
					}
				}
			}

			protected override void PublishOnCompleted(Result result)
			{
				lock (gate)
				{
					_003Cobserver_003EP.OnCompleted(result);
				}
			}
		}

		private sealed class SelectAwaitSequentialParallel : AwaitOperationSequentialParallelObserver<T, TResult>
		{
			public SelectAwaitSequentialParallel(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override ValueTask<TResult> OnNextTaskAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				return _003Cselector_003EP(value, cancellationToken);
			}

			protected override void PublishOnNext(T _, TResult result)
			{
				_003Cobserver_003EP.OnNext(result);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void PublishOnCompleted(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		private sealed class SelectAwaitParallelConcurrentLimit : AwaitOperationParallelConcurrentLimitObserver<T>
		{
			public SelectAwaitParallelConcurrentLimit(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted, maxConcurrent);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				TResult value2 = await _003Cselector_003EP(value, cancellationToken).ConfigureAwait(configureAwait);
				lock (gate)
				{
					_003Cobserver_003EP.OnNext(value2);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (gate)
				{
					_003Cobserver_003EP.OnErrorResume(error);
				}
			}

			protected override void PublishOnCompleted(Result result)
			{
				lock (gate)
				{
					_003Cobserver_003EP.OnCompleted(result);
				}
			}
		}

		private sealed class SelectAwaitSequentialParallelConcurrentLimit : AwaitOperationSequentialParallelConcurrentLimitObserver<T, TResult>
		{
			public SelectAwaitSequentialParallelConcurrentLimit(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted, maxConcurrent);
			}

			protected override ValueTask<TResult> OnNextTaskAsyncCore(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				return _003Cselector_003EP(value, cancellationToken);
			}

			protected override void PublishOnNext(T _, TResult result)
			{
				_003Cobserver_003EP.OnNext(result);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void PublishOnCompleted(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		private sealed class SelectAwaitThrottleFirstLast : AwaitOperationThrottleFirstLastObserver<T>
		{
			public SelectAwaitThrottleFirstLast(Observer<TResult> observer, Func<T, CancellationToken, ValueTask<TResult>> selector, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				TResult value2 = await _003Cselector_003EP(value, cancellationToken).ConfigureAwait(configureAwait);
				_003Cobserver_003EP.OnNext(value2);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void PublishOnCompleted(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public SelectAwait(Observable<T> source, Func<T, CancellationToken, ValueTask<TResult>> selector, AwaitOperation awaitOperation, bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
		{
			_003Csource_003EP = source;
			_003Cselector_003EP = selector;
			_003CawaitOperation_003EP = awaitOperation;
			_003CconfigureAwait_003EP = configureAwait;
			_003CcancelOnCompleted_003EP = cancelOnCompleted;
			_003CmaxConcurrent_003EP = maxConcurrent;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			switch (_003CawaitOperation_003EP)
			{
			case AwaitOperation.Sequential:
				return _003Csource_003EP.Subscribe(new SelectAwaitSequential(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			case AwaitOperation.Drop:
				return _003Csource_003EP.Subscribe(new SelectAwaitDrop(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			case AwaitOperation.Switch:
				return _003Csource_003EP.Subscribe(new SelectAwaitSwitch(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			case AwaitOperation.Parallel:
				if (_003CmaxConcurrent_003EP == -1)
				{
					return _003Csource_003EP.Subscribe(new SelectAwaitParallel(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
				}
				if (_003CmaxConcurrent_003EP == 0 || _003CmaxConcurrent_003EP < -1)
				{
					throw new ArgumentException("maxConcurrent must be a -1 or greater than 1.");
				}
				return _003Csource_003EP.Subscribe(new SelectAwaitParallelConcurrentLimit(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP, _003CmaxConcurrent_003EP));
			case AwaitOperation.SequentialParallel:
				if (_003CmaxConcurrent_003EP == -1)
				{
					return _003Csource_003EP.Subscribe(new SelectAwaitSequentialParallel(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
				}
				if (_003CmaxConcurrent_003EP == 0 || _003CmaxConcurrent_003EP < -1)
				{
					throw new ArgumentException("maxConcurrent must be a -1 or greater than 1.");
				}
				return _003Csource_003EP.Subscribe(new SelectAwaitSequentialParallelConcurrentLimit(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP, _003CmaxConcurrent_003EP));
			case AwaitOperation.ThrottleFirstLast:
				return _003Csource_003EP.Subscribe(new SelectAwaitThrottleFirstLast(observer, _003Cselector_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			default:
				throw new ArgumentException();
			}
		}
	}
}
