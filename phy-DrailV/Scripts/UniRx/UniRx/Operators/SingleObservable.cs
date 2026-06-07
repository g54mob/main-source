using System;

namespace UniRx.Operators
{
	internal class SingleObservable<T> : OperatorObservableBase<T>
	{
		private class Single : OperatorObserverBase<T, T>
		{
			private readonly SingleObservable<T> parent;

			private bool seenValue;

			private T lastValue;

			public Single(SingleObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
				seenValue = false;
			}

			public override void OnNext(T value)
			{
				if (seenValue)
				{
					try
					{
						observer.OnError(new InvalidOperationException("sequence is not single"));
						return;
					}
					finally
					{
						Dispose();
					}
				}
				seenValue = true;
				lastValue = value;
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
				if (parent.useDefault)
				{
					if (!seenValue)
					{
						observer.OnNext(default(T));
					}
					else
					{
						observer.OnNext(lastValue);
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
				if (!seenValue)
				{
					try
					{
						observer.OnError(new InvalidOperationException("sequence is empty"));
						return;
					}
					finally
					{
						Dispose();
					}
				}
				observer.OnNext(lastValue);
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

		private class Single_ : OperatorObserverBase<T, T>
		{
			private readonly SingleObservable<T> parent;

			private bool seenValue;

			private T lastValue;

			public Single_(SingleObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
				seenValue = false;
			}

			public override void OnNext(T value)
			{
				bool flag;
				try
				{
					flag = parent.predicate(value);
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
				if (!flag)
				{
					return;
				}
				if (seenValue)
				{
					try
					{
						observer.OnError(new InvalidOperationException("sequence is not single"));
						return;
					}
					finally
					{
						Dispose();
					}
				}
				seenValue = true;
				lastValue = value;
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
				if (parent.useDefault)
				{
					if (!seenValue)
					{
						observer.OnNext(default(T));
					}
					else
					{
						observer.OnNext(lastValue);
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
				if (!seenValue)
				{
					try
					{
						observer.OnError(new InvalidOperationException("sequence is empty"));
						return;
					}
					finally
					{
						Dispose();
					}
				}
				observer.OnNext(lastValue);
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

		private readonly bool useDefault;

		private readonly Func<T, bool> predicate;

		public SingleObservable(IObservable<T> source, bool useDefault)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.useDefault = useDefault;
		}

		public SingleObservable(IObservable<T> source, Func<T, bool> predicate, bool useDefault)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.predicate = predicate;
			this.useDefault = useDefault;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			if (predicate == null)
			{
				return source.Subscribe(new Single(this, observer, cancel));
			}
			return source.Subscribe(new Single_(this, observer, cancel));
		}
	}
}
