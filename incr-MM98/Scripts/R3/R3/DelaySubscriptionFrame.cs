using System;
using R3.Internal;

namespace R3
{
	internal sealed class DelaySubscriptionFrame<T> : Observable<T>
	{
		private sealed class _DelaySubscription : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly Observable<T> source;

			private readonly int frameCount;

			private readonly FrameProvider frameProvider;

			private int currentFrame;

			public _DelaySubscription(Observer<T> observer, Observable<T> source, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.source = source;
				this.frameCount = frameCount;
				this.frameProvider = frameProvider;
			}

			public IDisposable Run()
			{
				frameProvider.Register(this);
				return this;
			}

			protected override void OnNextCore(T value)
			{
				observer.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				observer.OnCompleted(result);
			}

			bool IFrameRunnerWorkItem.MoveNext(long _)
			{
				if (base.IsDisposed)
				{
					return false;
				}
				if (++currentFrame == frameCount)
				{
					try
					{
						source.Subscribe(this);
					}
					catch (Exception obj)
					{
						ObservableSystem.GetUnhandledExceptionHandler()(obj);
						Dispose();
					}
					return false;
				}
				return true;
			}
		}

		public DelaySubscriptionFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _DelaySubscription(observer, _003Csource_003EP, _003CframeCount_003EP.NormalizeFrame(), _003CframeProvider_003EP).Run();
		}
	}
}
