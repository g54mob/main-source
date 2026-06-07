using System;
using System.Threading;

namespace R3
{
	internal sealed class SubscribeOnFrameProvider<T> : Observable<T>
	{
		private sealed class _SubscribeOn : Observer<T>, IFrameRunnerWorkItem
		{
			private static readonly SendOrPostCallback postCallback = Subscribe;

			private readonly Observer<T> observer;

			private readonly Observable<T> source;

			private readonly FrameProvider frameProvider;

			private SingleAssignmentDisposableCore disposable;

			public _SubscribeOn(Observer<T> observer, Observable<T> source, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.source = source;
				this.frameProvider = frameProvider;
			}

			public IDisposable Run()
			{
				frameProvider.Register(this);
				return this;
			}

			private static void Subscribe(object? state)
			{
				_SubscribeOn subscribeOn = (_SubscribeOn)state;
				subscribeOn.disposable.Disposable = subscribeOn.source.Subscribe(subscribeOn);
			}

			bool IFrameRunnerWorkItem.MoveNext(long frameCount)
			{
				if (disposable.IsDisposed)
				{
					return false;
				}
				disposable.Disposable = source.Subscribe(this);
				return false;
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

			protected override void DisposeCore()
			{
				disposable.Dispose();
			}
		}

		public SubscribeOnFrameProvider(Observable<T> source, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _SubscribeOn(observer, _003Csource_003EP, _003CframeProvider_003EP).Run();
		}
	}
}
