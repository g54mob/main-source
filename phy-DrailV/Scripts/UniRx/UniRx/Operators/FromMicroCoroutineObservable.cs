using System;
using System.Collections;
using System.Threading;

namespace UniRx.Operators
{
	internal class FromMicroCoroutineObservable<T> : OperatorObservableBase<T>
	{
		private class FromMicroCoroutine : OperatorObserverBase<T, T>
		{
			public FromMicroCoroutine(IObserver<T> observer, IDisposable cancel)
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

		private readonly FrameCountType frameCountType;

		public FromMicroCoroutineObservable(Func<IObserver<T>, CancellationToken, IEnumerator> coroutine, FrameCountType frameCountType)
			: base(false)
		{
			this.coroutine = coroutine;
			this.frameCountType = frameCountType;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			FromMicroCoroutine arg = new FromMicroCoroutine(observer, cancel);
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			CancellationToken token = cancellationDisposable.Token;
			switch (frameCountType)
			{
			case FrameCountType.Update:
				MainThreadDispatcher.StartUpdateMicroCoroutine(coroutine(arg, token));
				break;
			case FrameCountType.FixedUpdate:
				MainThreadDispatcher.StartFixedUpdateMicroCoroutine(coroutine(arg, token));
				break;
			case FrameCountType.EndOfFrame:
				MainThreadDispatcher.StartEndOfFrameMicroCoroutine(coroutine(arg, token));
				break;
			default:
				throw new ArgumentException("Invalid FrameCountType:" + frameCountType);
			}
			return cancellationDisposable;
		}
	}
}
