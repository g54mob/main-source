using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class FromAsync : Observable<Unit>
	{
		public FromAsync(Func<CancellationToken, ValueTask> asyncFactory, bool configureAwait)
		{
			_003CasyncFactory_003EP = asyncFactory;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			SubscribeTask(observer, cancellationDisposable.Token);
			return cancellationDisposable;
		}

		private async void SubscribeTask(Observer<Unit> observer, CancellationToken cancellationToken)
		{
			try
			{
				await _003CasyncFactory_003EP(cancellationToken).ConfigureAwait(_003CconfigureAwait_003EP);
			}
			catch (Exception ex)
			{
				if ((!(ex is OperationCanceledException ex2) || !(ex2.CancellationToken == cancellationToken)) && !cancellationToken.IsCancellationRequested)
				{
					observer.OnCompleted(ex);
				}
				return;
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				observer.OnNext(default(Unit));
				observer.OnCompleted();
			}
		}
	}
	internal sealed class FromAsync<T> : Observable<T>
	{
		public FromAsync(Func<CancellationToken, ValueTask<T>> asyncFactory, bool configureAwait)
		{
			_003CasyncFactory_003EP = asyncFactory;
			_003CconfigureAwait_003EP = configureAwait;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			SubscribeTask(observer, cancellationDisposable.Token);
			return cancellationDisposable;
		}

		private async void SubscribeTask(Observer<T> observer, CancellationToken cancellationToken)
		{
			T value;
			try
			{
				value = await _003CasyncFactory_003EP(cancellationToken).ConfigureAwait(_003CconfigureAwait_003EP);
			}
			catch (Exception ex)
			{
				if ((!(ex is OperationCanceledException ex2) || !(ex2.CancellationToken == cancellationToken)) && !cancellationToken.IsCancellationRequested)
				{
					observer.OnCompleted(ex);
				}
				return;
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				observer.OnNext(value);
				observer.OnCompleted();
			}
		}
	}
}
