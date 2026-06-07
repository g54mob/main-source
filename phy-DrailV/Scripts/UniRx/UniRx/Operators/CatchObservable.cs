using System;
using System.Collections.Generic;

namespace UniRx.Operators
{
	internal class CatchObservable<T, TException> : OperatorObservableBase<T> where TException : Exception
	{
		private class Catch : OperatorObserverBase<T, T>
		{
			private readonly CatchObservable<T, TException> parent;

			private SingleAssignmentDisposable sourceSubscription;

			private SingleAssignmentDisposable exceptionSubscription;

			public Catch(CatchObservable<T, TException> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
			}

			public IDisposable Run()
			{
				sourceSubscription = new SingleAssignmentDisposable();
				exceptionSubscription = new SingleAssignmentDisposable();
				sourceSubscription.Disposable = parent.source.Subscribe(this);
				return StableCompositeDisposable.Create(sourceSubscription, exceptionSubscription);
			}

			public override void OnNext(T value)
			{
				observer.OnNext(value);
			}

			public override void OnError(Exception error)
			{
				if (error is TException arg)
				{
					IObservable<T> observable;
					try
					{
						observable = ((parent.errorHandler != new Func<TException, IObservable<T>>(Stubs.CatchIgnore<T>)) ? parent.errorHandler(arg) : Observable.Empty<T>());
					}
					catch (Exception error2)
					{
						try
						{
							observer.OnError(error2);
							return;
						}
						finally
						{
							Dispose();
						}
					}
					exceptionSubscription.Disposable = observable.Subscribe(observer);
					return;
				}
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

		private readonly IObservable<T> source;

		private readonly Func<TException, IObservable<T>> errorHandler;

		public CatchObservable(IObservable<T> source, Func<TException, IObservable<T>> errorHandler)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.errorHandler = errorHandler;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			return new Catch(this, observer, cancel).Run();
		}
	}
	internal class CatchObservable<T> : OperatorObservableBase<T>
	{
		private class Catch : OperatorObserverBase<T, T>
		{
			private readonly CatchObservable<T> parent;

			private readonly object gate = new object();

			private bool isDisposed;

			private IEnumerator<IObservable<T>> e;

			private SerialDisposable subscription;

			private Exception lastException;

			private Action nextSelf;

			public Catch(CatchObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
			}

			public IDisposable Run()
			{
				isDisposed = false;
				e = parent.sources.GetEnumerator();
				subscription = new SerialDisposable();
				return StableCompositeDisposable.Create(Scheduler.DefaultSchedulers.TailRecursion.Schedule(RecursiveRun), subscription, Disposable.Create(delegate
				{
					lock (gate)
					{
						isDisposed = true;
						e.Dispose();
					}
				}));
			}

			private void RecursiveRun(Action self)
			{
				lock (gate)
				{
					nextSelf = self;
					if (isDisposed)
					{
						return;
					}
					IObservable<T> observable = null;
					bool flag = false;
					Exception ex = null;
					try
					{
						flag = e.MoveNext();
						if (flag)
						{
							observable = e.Current;
							if (observable == null)
							{
								throw new InvalidOperationException("sequence is null.");
							}
						}
						else
						{
							e.Dispose();
						}
					}
					catch (Exception ex2)
					{
						ex = ex2;
						e.Dispose();
					}
					if (ex != null)
					{
						try
						{
							observer.OnError(ex);
							return;
						}
						finally
						{
							Dispose();
						}
					}
					if (!flag)
					{
						if (lastException != null)
						{
							try
							{
								observer.OnError(lastException);
								return;
							}
							finally
							{
								Dispose();
							}
						}
						try
						{
							observer.OnCompleted();
							return;
						}
						finally
						{
							Dispose();
						}
					}
					IObservable<T> observable2 = observable;
					SingleAssignmentDisposable singleAssignmentDisposable = new SingleAssignmentDisposable();
					subscription.Disposable = singleAssignmentDisposable;
					singleAssignmentDisposable.Disposable = observable2.Subscribe(this);
				}
			}

			public override void OnNext(T value)
			{
				observer.OnNext(value);
			}

			public override void OnError(Exception error)
			{
				lastException = error;
				nextSelf();
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

		private readonly IEnumerable<IObservable<T>> sources;

		public CatchObservable(IEnumerable<IObservable<T>> sources)
			: base(true)
		{
			this.sources = sources;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			return new Catch(this, observer, cancel).Run();
		}
	}
}
