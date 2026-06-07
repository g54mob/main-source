using System;

namespace R3
{
	internal sealed class Scan<TSource> : Observable<TSource>
	{
		private sealed class _Scan : Observer<TSource>
		{
			private readonly Observer<TSource> observer;

			private readonly Func<TSource, TSource, TSource> accumulator;

			private TSource state;

			private bool hasValue;

			public _Scan(Observer<TSource> observer, Func<TSource, TSource, TSource> accumulator)
			{
				this.observer = observer;
				state = default(TSource);
				this.accumulator = accumulator;
			}

			protected override void OnNextCore(TSource value)
			{
				if (!hasValue)
				{
					hasValue = true;
					state = value;
					observer.OnNext(state);
				}
				else
				{
					state = accumulator(state, value);
					observer.OnNext(state);
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
		}

		public Scan(Observable<TSource> source, Func<TSource, TSource, TSource> accumulator)
		{
			_003Csource_003EP = source;
			_003Caccumulator_003EP = accumulator;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TSource> observer)
		{
			return _003Csource_003EP.Subscribe(new _Scan(observer, _003Caccumulator_003EP));
		}
	}
	internal sealed class Scan<TSource, TAccumulate> : Observable<TAccumulate>
	{
		private sealed class _Scan : Observer<TSource>
		{
			private readonly Observer<TAccumulate> observer;

			private readonly Func<TAccumulate, TSource, TAccumulate> accumulator;

			private TAccumulate state;

			public _Scan(Observer<TAccumulate> observer, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
			{
				this.observer = observer;
				state = seed;
				this.accumulator = accumulator;
			}

			protected override void OnNextCore(TSource value)
			{
				state = accumulator(state, value);
				observer.OnNext(state);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				observer.OnCompleted(result);
			}
		}

		public Scan(Observable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
		{
			_003Csource_003EP = source;
			_003Cseed_003EP = seed;
			_003Caccumulator_003EP = accumulator;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TAccumulate> observer)
		{
			return _003Csource_003EP.Subscribe(new _Scan(observer, _003Cseed_003EP, _003Caccumulator_003EP));
		}
	}
}
