using System;

namespace UniRx.Operators
{
	internal class PairwiseObservable<T, TR> : OperatorObservableBase<TR>
	{
		private class Pairwise : OperatorObserverBase<T, TR>
		{
			private readonly PairwiseObservable<T, TR> parent;

			private T prev;

			private bool isFirst = true;

			public Pairwise(PairwiseObservable<T, TR> parent, IObserver<TR> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
			}

			public override void OnNext(T value)
			{
				if (isFirst)
				{
					isFirst = false;
					prev = value;
					return;
				}
				TR value2;
				try
				{
					value2 = parent.selector(prev, value);
					prev = value;
				}
				catch (Exception error)
				{
					try
					{
						observer.OnError(error);
						return;
					}
					finally
					{
						Dispose();
					}
				}
				observer.OnNext(value2);
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

		private readonly IObservable<T> source;

		private readonly Func<T, T, TR> selector;

		public PairwiseObservable(IObservable<T> source, Func<T, T, TR> selector)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.selector = selector;
		}

		protected override IDisposable SubscribeCore(IObserver<TR> observer, IDisposable cancel)
		{
			return source.Subscribe(new Pairwise(this, observer, cancel));
		}
	}
	internal class PairwiseObservable<T> : OperatorObservableBase<Pair<T>>
	{
		private class Pairwise : OperatorObserverBase<T, Pair<T>>
		{
			private T prev;

			private bool isFirst = true;

			public Pairwise(IObserver<Pair<T>> observer, IDisposable cancel)
				: base(observer, cancel)
			{
			}

			public override void OnNext(T value)
			{
				if (isFirst)
				{
					isFirst = false;
					prev = value;
				}
				else
				{
					Pair<T> value2 = new Pair<T>(prev, value);
					prev = value;
					observer.OnNext(value2);
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

		private readonly IObservable<T> source;

		public PairwiseObservable(IObservable<T> source)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
		}

		protected override IDisposable SubscribeCore(IObserver<Pair<T>> observer, IDisposable cancel)
		{
			return source.Subscribe(new Pairwise(observer, cancel));
		}
	}
}
