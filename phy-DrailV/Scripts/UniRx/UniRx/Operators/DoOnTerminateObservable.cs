using System;

namespace UniRx.Operators
{
	internal class DoOnTerminateObservable<T> : OperatorObservableBase<T>
	{
		private class DoOnTerminate : OperatorObserverBase<T, T>
		{
			private readonly DoOnTerminateObservable<T> parent;

			public DoOnTerminate(DoOnTerminateObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
			}

			public IDisposable Run()
			{
				return parent.source.Subscribe(this);
			}

			public override void OnNext(T value)
			{
				observer.OnNext(value);
			}

			public override void OnError(Exception error)
			{
				try
				{
					parent.onTerminate();
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
					parent.onTerminate();
				}
				catch (Exception error)
				{
					observer.OnError(error);
					Dispose();
					return;
				}
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

		private readonly Action onTerminate;

		public DoOnTerminateObservable(IObservable<T> source, Action onTerminate)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.onTerminate = onTerminate;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			return new DoOnTerminate(this, observer, cancel).Run();
		}
	}
}
