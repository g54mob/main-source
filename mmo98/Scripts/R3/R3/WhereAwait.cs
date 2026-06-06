using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class WhereAwait<T> : Observable<T>
	{
		private sealed class WhereAwaitSequential : AwaitOperationSequentialObserver<T>
		{
			public WhereAwaitSequential(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				if (await _003Cpredicate_003EP(value, cancellationToken).ConfigureAwait(configureAwait) && !cancellationToken.IsCancellationRequested)
				{
					_003Cobserver_003EP.OnNext(value);
				}
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

		private sealed class WhereAwaitDrop : AwaitOperationDropObserver<T>
		{
			public WhereAwaitDrop(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				if (await _003Cpredicate_003EP(value, cancellationToken).ConfigureAwait(configureAwait))
				{
					_003Cobserver_003EP.OnNext(value);
				}
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

		private sealed class WhereAwaitParallel : AwaitOperationParallelObserver<T>
		{
			public WhereAwaitParallel(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				if (await _003Cpredicate_003EP(value, cancellationToken).ConfigureAwait(configureAwait))
				{
					lock (gate)
					{
						_003Cobserver_003EP.OnNext(value);
					}
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

		private sealed class WhereAwaitSwitch : AwaitOperationSwitchObserver<T>
		{
			public WhereAwaitSwitch(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				if (await _003Cpredicate_003EP(value, cancellationToken).ConfigureAwait(configureAwait))
				{
					lock (gate)
					{
						_003Cobserver_003EP.OnNext(value);
					}
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

		private sealed class WhereAwaitSequentialParallel : AwaitOperationSequentialParallelObserver<T, bool>
		{
			public WhereAwaitSequentialParallel(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override ValueTask<bool> OnNextTaskAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				return _003Cpredicate_003EP(value, cancellationToken);
			}

			protected override void PublishOnNext(T value, bool result)
			{
				if (result)
				{
					_003Cobserver_003EP.OnNext(value);
				}
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

		private sealed class WhereAwaitParallelConcurrentLimit : AwaitOperationParallelConcurrentLimitObserver<T>
		{
			public WhereAwaitParallelConcurrentLimit(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted, maxConcurrent);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				if (await _003Cpredicate_003EP(value, cancellationToken).ConfigureAwait(configureAwait))
				{
					lock (gate)
					{
						_003Cobserver_003EP.OnNext(value);
					}
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

		private sealed class WhereAwaitSequentialParallelConcurrentLimit : AwaitOperationSequentialParallelConcurrentLimitObserver<T, bool>
		{
			public WhereAwaitSequentialParallelConcurrentLimit(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted, maxConcurrent);
			}

			protected override ValueTask<bool> OnNextTaskAsyncCore(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				return _003Cpredicate_003EP(value, cancellationToken);
			}

			protected override void PublishOnNext(T value, bool result)
			{
				if (result)
				{
					_003Cobserver_003EP.OnNext(value);
				}
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

		private sealed class WhereAwaitThrottleFirstLast : AwaitOperationThrottleFirstLastObserver<T>
		{
			public WhereAwaitThrottleFirstLast(Observer<T> observer, Func<T, CancellationToken, ValueTask<bool>> predicate, bool configureAwait, bool cancelOnCompleted)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector(configureAwait, cancelOnCompleted);
			}

			protected override async ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
			{
				if (await _003Cpredicate_003EP(value, cancellationToken).ConfigureAwait(configureAwait) && !cancellationToken.IsCancellationRequested)
				{
					_003Cobserver_003EP.OnNext(value);
				}
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

		public WhereAwait(Observable<T> source, Func<T, CancellationToken, ValueTask<bool>> predicate, AwaitOperation awaitOperation, bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
		{
			_003Csource_003EP = source;
			_003Cpredicate_003EP = predicate;
			_003CawaitOperation_003EP = awaitOperation;
			_003CconfigureAwait_003EP = configureAwait;
			_003CcancelOnCompleted_003EP = cancelOnCompleted;
			_003CmaxConcurrent_003EP = maxConcurrent;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			switch (_003CawaitOperation_003EP)
			{
			case AwaitOperation.Sequential:
				return _003Csource_003EP.Subscribe(new WhereAwaitSequential(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			case AwaitOperation.Drop:
				return _003Csource_003EP.Subscribe(new WhereAwaitDrop(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			case AwaitOperation.Switch:
				return _003Csource_003EP.Subscribe(new WhereAwaitSwitch(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			case AwaitOperation.Parallel:
				if (_003CmaxConcurrent_003EP == -1)
				{
					return _003Csource_003EP.Subscribe(new WhereAwaitParallel(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
				}
				if (_003CmaxConcurrent_003EP == 0 || _003CmaxConcurrent_003EP < -1)
				{
					throw new ArgumentException("maxConcurrent must be a -1 or greater than 1.");
				}
				return _003Csource_003EP.Subscribe(new WhereAwaitParallelConcurrentLimit(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP, _003CmaxConcurrent_003EP));
			case AwaitOperation.SequentialParallel:
				if (_003CmaxConcurrent_003EP == -1)
				{
					return _003Csource_003EP.Subscribe(new WhereAwaitSequentialParallel(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
				}
				if (_003CmaxConcurrent_003EP == 0 || _003CmaxConcurrent_003EP < -1)
				{
					throw new ArgumentException("maxConcurrent must be a -1 or greater than 1.");
				}
				return _003Csource_003EP.Subscribe(new WhereAwaitSequentialParallelConcurrentLimit(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP, _003CmaxConcurrent_003EP));
			case AwaitOperation.ThrottleFirstLast:
				return _003Csource_003EP.Subscribe(new WhereAwaitThrottleFirstLast(observer, _003Cpredicate_003EP, _003CconfigureAwait_003EP, _003CcancelOnCompleted_003EP));
			default:
				throw new ArgumentException();
			}
		}
	}
}
