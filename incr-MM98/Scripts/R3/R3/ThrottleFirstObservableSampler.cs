using System;

namespace R3
{
	internal sealed class ThrottleFirstObservableSampler<T, TSample> : Observable<T>
	{
		private sealed class _ThrottleFirst : Observer<T>
		{
			private sealed class SamplerObserver : Observer<TSample>
			{
				public SamplerObserver(_ThrottleFirst parent)
				{
					_003Cparent_003EP = parent;
					base._002Ector();
				}

				protected override void OnNextCore(TSample value)
				{
					lock (_003Cparent_003EP.gate)
					{
						_003Cparent_003EP.closing = false;
					}
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

			private bool closing;

			public _ThrottleFirst(Observer<T> observer, Observable<TSample> sampler)
			{
				this.observer = observer;
				SamplerObserver samplerObserver = new SamplerObserver(this);
				samplerSubscription = sampler.Subscribe(samplerObserver);
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!closing)
					{
						closing = true;
						observer.OnNext(value);
					}
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
		}

		public ThrottleFirstObservableSampler(Observable<T> source, Observable<TSample> sampler)
		{
			_003Csource_003EP = source;
			_003Csampler_003EP = sampler;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleFirst(observer, _003Csampler_003EP));
		}
	}
}
