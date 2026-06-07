using System;

namespace R3
{
	internal sealed class ThrottleLastObservableSampler<T, TSample> : Observable<T>
	{
		private sealed class _ThrottleLast : Observer<T>
		{
			private sealed class SamplerObserver : Observer<TSample>
			{
				public SamplerObserver(_ThrottleLast parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(TSample value)
				{
					_003Cparent_003EP.PublishOnNext();
				}

				protected override void OnErrorResumeCore(Exception error)
				{
					_003Cparent_003EP.OnErrorResume(error);
				}

				protected override void OnCompletedCore(Result result)
				{
					_003Cparent_003EP.OnCompleted(result);
				}
			}

			private readonly Observer<T> observer;

			private readonly object gate = new object();

			private readonly IDisposable samplerSubscription;

			private T? lastValue;

			private bool hasValue;

			public _ThrottleLast(Observer<T> observer, Observable<TSample> sampler)
			{
				this.observer = observer;
				SamplerObserver samplerObserver = new SamplerObserver(this);
				samplerSubscription = sampler.Subscribe(samplerObserver);
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					lastValue = value;
					hasValue = true;
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
				samplerSubscription.Dispose();
			}

			private void PublishOnNext()
			{
				lock (gate)
				{
					if (hasValue)
					{
						observer.OnNext(lastValue);
						hasValue = false;
						lastValue = default(T);
					}
				}
			}
		}

		public ThrottleLastObservableSampler(Observable<T> source, Observable<TSample> sampler)
		{
			_003Csource_003EP = source;
			_003Csampler_003EP = sampler;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleLast(observer, _003Csampler_003EP));
		}
	}
}
