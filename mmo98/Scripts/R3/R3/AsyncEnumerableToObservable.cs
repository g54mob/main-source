using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class AsyncEnumerableToObservable<T> : Observable<T>
	{
		public AsyncEnumerableToObservable(IAsyncEnumerable<T> source)
		{
			_003Csource_003EP = source;
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
				await foreach (T item in _003Csource_003EP.WithCancellation(cancellationToken))
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
