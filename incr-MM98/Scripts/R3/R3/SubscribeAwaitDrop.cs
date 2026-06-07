using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class SubscribeAwaitDrop<T> : AwaitOperationDropObserver<T>
	{
		public SubscribeAwaitDrop(Func<T, CancellationToken, ValueTask> onNextAsync, Action<Exception> onErrorResume, Action<Result> onCompleted, bool configureAwait, bool cancelOnCompleted)
		{
			_003ConNextAsync_003EP = onNextAsync;
			_003ConErrorResume_003EP = onErrorResume;
			_003ConCompleted_003EP = onCompleted;
			base._002Ector(configureAwait, cancelOnCompleted);
		}

		protected override ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
		{
			return _003ConNextAsync_003EP(value, cancellationToken);
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			_003ConErrorResume_003EP(error);
		}

		protected override void PublishOnCompleted(Result result)
		{
			_003ConCompleted_003EP(result);
		}
	}
	internal sealed class SubscribeAwaitDrop<T, TState> : AwaitOperationDropObserver<T>
	{
		public SubscribeAwaitDrop(TState state, Func<T, TState, CancellationToken, ValueTask> onNextAsync, Action<Exception, TState> onErrorResume, Action<Result, TState> onCompleted, bool configureAwait, bool cancelOnCompleted)
		{
			_003Cstate_003EP = state;
			_003ConNextAsync_003EP = onNextAsync;
			_003ConErrorResume_003EP = onErrorResume;
			_003ConCompleted_003EP = onCompleted;
			base._002Ector(configureAwait, cancelOnCompleted);
		}

		protected override ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait)
		{
			return _003ConNextAsync_003EP(value, _003Cstate_003EP, cancellationToken);
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			_003ConErrorResume_003EP(error, _003Cstate_003EP);
		}

		protected override void PublishOnCompleted(Result result)
		{
			_003ConCompleted_003EP(result, _003Cstate_003EP);
		}
	}
}
