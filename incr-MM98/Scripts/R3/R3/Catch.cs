using System;

namespace R3
{
	internal sealed class Catch<T> : Observable<T>
	{
		private sealed class _Catch : IDisposable
		{
			internal sealed class FirstObserver : Observer<T>
			{
				public FirstObserver(_Catch parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					_003Cparent_003EP.observer.OnNext(value);
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					if (result.IsFailure)
					{
						_003Cparent_003EP.secondSubscription.Disposable = _003Cparent_003EP.second.Subscribe(new SecondObserver(_003Cparent_003EP));
					}
					else
					{
						_003Cparent_003EP.observer.OnCompleted(result);
					}
				}
			}

			internal sealed class SecondObserver : Observer<T>
			{
				public SecondObserver(_Catch parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					_003Cparent_003EP.observer.OnNext(value);
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					_003Cparent_003EP.observer.OnCompleted(result);
				}

				protected override void DisposeCore()
				{
					_003Cparent_003EP.Dispose();
				}
			}

			private readonly Observer<T> observer;

			private readonly Observable<T> second;

			private SingleAssignmentDisposableCore firstSubscription;

			private SingleAssignmentDisposableCore secondSubscription;

			public _Catch(Observer<T> observer, Observable<T> second)
			{
				this.observer = observer;
				this.second = second;
				base._002Ector();
			}

			public IDisposable Run(Observable<T> source)
			{
				return source.Subscribe(new FirstObserver(this));
			}

			public void Dispose()
			{
				firstSubscription.Dispose();
				secondSubscription.Dispose();
			}
		}

		public Catch(Observable<T> source, Observable<T> second)
		{
			_003Csource_003EP = source;
			_003Csecond_003EP = second;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _Catch(observer, _003Csecond_003EP).Run(_003Csource_003EP);
		}
	}
	internal sealed class Catch<T, TException> : Observable<T>
	{
		private sealed class _Catch : IDisposable
		{
			internal sealed class FirstObserver : Observer<T>
			{
				public FirstObserver(_Catch parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					_003Cparent_003EP.observer.OnNext(value);
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					if (result.IsFailure && result.Exception is TException arg)
					{
						_003Cparent_003EP.secondSubscription.Disposable = _003Cparent_003EP.errorHandler(arg).Subscribe(new SecondObserver(_003Cparent_003EP));
					}
					else
					{
						_003Cparent_003EP.observer.OnCompleted(result);
					}
				}
			}

			internal sealed class SecondObserver : Observer<T>
			{
				public SecondObserver(_Catch parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(T value)
				{
					_003Cparent_003EP.observer.OnNext(value);
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.observer.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					_003Cparent_003EP.observer.OnCompleted(result);
				}

				protected override void DisposeCore()
				{
					_003Cparent_003EP.Dispose();
				}
			}

			private readonly Observer<T> observer;

			private readonly Func<TException, Observable<T>> errorHandler;

			private SingleAssignmentDisposableCore firstSubscription;

			private SingleAssignmentDisposableCore secondSubscription;

			public _Catch(Observer<T> observer, Func<TException, Observable<T>> errorHandler)
			{
				this.observer = observer;
				this.errorHandler = errorHandler;
				base._002Ector();
			}

			public IDisposable Run(Observable<T> source)
			{
				return source.Subscribe(new FirstObserver(this));
			}

			public void Dispose()
			{
				firstSubscription.Dispose();
				secondSubscription.Dispose();
			}
		}

		public Catch(Observable<T> source, Func<TException, Observable<T>> errorHandler)
		{
			_003Csource_003EP = source;
			_003CerrorHandler_003EP = errorHandler;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _Catch(observer, _003CerrorHandler_003EP).Run(_003Csource_003EP);
		}
	}
}
