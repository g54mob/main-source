using System;
using System.Collections.Generic;
using System.Threading;

namespace R3
{
	internal sealed class CreateFrom<T> : Observable<T>
	{
		public CreateFrom(Func<CancellationToken, IAsyncEnumerable<T>> factory)
		{
			_003Cfactory_003EP = factory;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			RunAsync(observer, cancellationDisposable.Token);
			return cancellationDisposable;
		}

		private async void RunAsync(Observer<T> observer, CancellationToken cancellationToken)
		{
			_ = 1;
			try
			{
				await foreach (T item in _003Cfactory_003EP(cancellationToken))
				{
					observer.OnNext(item);
				}
				observer.OnCompleted();
			}
			catch (Exception ex)
			{
				if (!(ex is OperationCanceledException ex2) || !(ex2.CancellationToken == cancellationToken))
				{
					observer.OnCompleted(Result.Failure(ex));
				}
			}
		}
	}
	internal sealed class CreateFrom<T, TState> : Observable<T>
	{
		public CreateFrom(TState state, Func<CancellationToken, TState, IAsyncEnumerable<T>> factory)
		{
			_003Cstate_003EP = state;
			_003Cfactory_003EP = factory;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			RunAsync(observer, cancellationDisposable.Token);
			return cancellationDisposable;
		}

		private async void RunAsync(Observer<T> observer, CancellationToken cancellationToken)
		{
			_ = 1;
			try
			{
				await foreach (T item in _003Cfactory_003EP(cancellationToken, _003Cstate_003EP))
				{
					observer.OnNext(item);
				}
				observer.OnCompleted();
			}
			catch (Exception ex)
			{
				if (!(ex is OperationCanceledException ex2) || !(ex2.CancellationToken == cancellationToken))
				{
					observer.OnCompleted(Result.Failure(ex));
				}
			}
		}
	}
}
