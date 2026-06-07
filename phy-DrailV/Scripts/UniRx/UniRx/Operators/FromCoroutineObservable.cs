using System;
using System.Collections;
using System.Threading;

namespace UniRx.Operators
{
	internal class FromCoroutineObservable<T> : OperatorObservableBase<T>
	{
		private class FromCoroutine : OperatorObserverBase<T, T>
		{
			public FromCoroutine(IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
			}

			public override void OnNext(T value)
			{
				try
				{
					observer.OnNext(value);
				}
				catch
				{
					Dispose();
					throw;
				}
			}

			public override void OnError(Exception error)
			{
				try
				{
					observer.OnError(error);
				}
				finally
				{
					Dispose();
				}
			}

			public override void OnCompleted()
			{
				try
				{
					observer.OnCompleted();
				}
				finally
				{
					Dispose();
				}
			}
		}

		private readonly Func<IObserver<T>, CancellationToken, IEnumerator> coroutine;

		public FromCoroutineObservable(Func<IObserver<T>, CancellationToken, IEnumerator> coroutine)
			: base(false)
		{
			this.coroutine = coroutine;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			FromCoroutine arg = new FromCoroutine(observer, cancel);
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			CancellationToken token = cancellationDisposable.Token;
			MainThreadDispatcher.SendStartCoroutine(coroutine(arg, token));
			return cancellationDisposable;
		}
	}
}
