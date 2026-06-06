using System;
using System.Collections.Generic;
using R3.Internal;

namespace R3
{
	internal sealed class DelayFrame<T> : Observable<T>
	{
		private sealed class _DelayFrame : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly int frameCount;

			private readonly FrameProvider frameProvider;

			private readonly Queue<(long timestamp, Notification<T> value)> queue = new Queue<(long, Notification<T>)>();

			private bool running;

			private long currentFrame;

			protected override bool AutoDisposeOnCompleted => false;

			public _DelayFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.frameCount = frameCount;
				this.observer = observer;
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				lock (queue)
				{
					queue.Enqueue((frameProvider.GetFrameCount(), new Notification<T>(value)));
					if (queue.Count == 1 && !running)
					{
						running = true;
						currentFrame = frameProvider.GetFrameCount();
						frameProvider.Register(this);
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (queue)
				{
					queue.Enqueue((frameProvider.GetFrameCount(), new Notification<T>(error)));
					if (queue.Count == 1 && !running)
					{
						running = true;
						currentFrame = frameProvider.GetFrameCount();
						frameProvider.Register(this);
					}
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (queue)
				{
					queue.Enqueue((frameProvider.GetFrameCount(), new Notification<T>(result)));
					if (queue.Count == 1 && !running)
					{
						running = true;
						currentFrame = frameProvider.GetFrameCount();
						frameProvider.Register(this);
					}
				}
			}

			protected override void DisposeCore()
			{
				lock (queue)
				{
					queue.Clear();
				}
			}

			bool IFrameRunnerWorkItem.MoveNext(long _)
			{
				currentFrame++;
				while (!base.IsDisposed)
				{
					Notification<T> item;
					lock (queue)
					{
						if (!queue.TryPeek(out (long, Notification<T>) result))
						{
							running = false;
							return false;
						}
						if (currentFrame - result.Item1 < frameCount)
						{
							return true;
						}
						item = queue.Dequeue().value;
					}
					try
					{
						switch (item.Kind)
						{
						case NotificationKind.OnNext:
							observer.OnNext(item.Value);
							break;
						case NotificationKind.OnErrorResume:
							observer.OnErrorResume(item.Error);
							break;
						case NotificationKind.OnCompleted:
							try
							{
								observer.OnCompleted(item.Result);
							}
							finally
							{
								Dispose();
							}
							break;
						}
					}
					catch (Exception obj)
					{
						ObservableSystem.GetUnhandledExceptionHandler()(obj);
					}
				}
				return false;
			}
		}

		public DelayFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _DelayFrame(observer, _003CframeCount_003EP.NormalizeFrame(), _003CframeProvider_003EP));
		}
	}
}
