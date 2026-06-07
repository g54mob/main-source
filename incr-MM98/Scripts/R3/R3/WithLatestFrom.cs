using System;
using System.Threading;

namespace R3
{
	internal sealed class WithLatestFrom<TFirst, TSecond, TResult> : Observable<TResult>
	{
		private sealed class WithLatestFromFirstObserver : Observer<TFirst>
		{
			public Observer<TResult> observer;

			public bool hasSecondValue;

			public TSecond? secondValue;

			public SingleAssignmentDisposableCore secondDisposable;

			public WithLatestFromFirstObserver(Observer<TResult> observer, Func<TFirst, TSecond, TResult> resultSelector)
			{
				_003CresultSelector_003EP = resultSelector;
				this.observer = observer;
				base._002Ector();
			}

			protected override void OnNextCore(TFirst value)
			{
				if (hasSecondValue)
				{
					TResult value2 = _003CresultSelector_003EP(value, secondValue);
					observer.OnNext(value2);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				observer.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				secondDisposable.Dispose();
			}
		}

		private sealed class WithLatestFromSecondObserver : Observer<TSecond>
		{
			public WithLatestFromSecondObserver(WithLatestFromFirstObserver left)
			{
				_003Cleft_003EP = left;
				base._002Ector();
			}

			protected override void OnNextCore(TSecond value)
			{
				_003Cleft_003EP.secondValue = value;
				Interlocked.MemoryBarrier();
				_003Cleft_003EP.hasSecondValue = true;
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cleft_003EP.observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					_003Cleft_003EP.observer.OnCompleted(result);
				}
			}
		}

		public WithLatestFrom(Observable<TFirst> first, Observable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			_003Cfirst_003EP = first;
			_003Csecond_003EP = second;
			_003CresultSelector_003EP = resultSelector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			WithLatestFromFirstObserver withLatestFromFirstObserver = new WithLatestFromFirstObserver(observer, _003CresultSelector_003EP);
			WithLatestFromSecondObserver withLatestFromSecondObserver = new WithLatestFromSecondObserver(withLatestFromFirstObserver);
			withLatestFromFirstObserver.secondDisposable.Disposable = withLatestFromSecondObserver;
			_003Csecond_003EP.Subscribe(withLatestFromSecondObserver);
			try
			{
				_003Cfirst_003EP.Subscribe(withLatestFromFirstObserver);
				return withLatestFromFirstObserver;
			}
			catch
			{
				withLatestFromSecondObserver.Dispose();
				throw;
			}
		}
	}
}
