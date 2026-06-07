using System;

namespace UniRx.Operators
{
	internal class TakeObservable<T> : OperatorObservableBase<T>
	{
		private class Take : OperatorObserverBase<T, T>
		{
			private int rest;

			public Take(TakeObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				rest = parent.count;
			}

			public override void OnNext(T value)
			{
				if (rest <= 0)
				{
					return;
				}
				rest--;
				observer.OnNext(value);
				if (rest == 0)
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

		private class Take_ : OperatorObserverBase<T, T>
		{
			private readonly TakeObservable<T> parent;

			private readonly object gate = new object();

			public Take_(TakeObservable<T> parent, IObserver<T> observer, IDisposable cancel)
				: base(observer, cancel)
			{
				this.parent = parent;
			}

			public IDisposable Run()
			{
				IDisposable disposable = parent.scheduler.Schedule(parent.duration, Tick);
				IDisposable disposable2 = parent.source.Subscribe(this);
				return StableCompositeDisposable.Create(disposable, disposable2);
			}

			private void Tick()
			{
				lock (gate)
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

			public override void OnNext(T value)
			{
				lock (gate)
				{
					observer.OnNext(value);
				}
			}

			public override void OnError(Exception error)
			{
				lock (gate)
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
			}

			public override void OnCompleted()
			{
				lock (gate)
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
		}

		private readonly IObservable<T> source;

		private readonly int count;

		private readonly TimeSpan duration;

		internal readonly IScheduler scheduler;

		public TakeObservable(IObservable<T> source, int count)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.count = count;
		}

		public TakeObservable(IObservable<T> source, TimeSpan duration, IScheduler scheduler)
			: base(scheduler == Scheduler.CurrentThread || source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
			this.duration = duration;
			this.scheduler = scheduler;
		}

		public IObservable<T> Combine(int count)
		{
			if (this.count > count)
			{
				return new TakeObservable<T>(source, count);
			}
			return this;
		}

		public IObservable<T> Combine(TimeSpan duration)
		{
			if (!(this.duration <= duration))
			{
				return new TakeObservable<T>(source, duration, scheduler);
			}
			return this;
		}

		protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
		{
			if (scheduler == null)
			{
				return source.Subscribe(new Take(this, observer, cancel));
			}
			return new Take_(this, observer, cancel).Run();
		}
	}
}
