using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ReturnFrameTime<T> : Observable<T>
	{
		private sealed class ReturnFrameTimeRunnerWorkItem : CancellableFrameRunnerWorkItemBase<T>
		{
			private int currentFrame;

			public ReturnFrameTimeRunnerWorkItem(T value, int dueTimeFrame, Observer<T> observer, CancellationToken cancellationToken)
			{
				_003Cvalue_003EP = value;
				_003CdueTimeFrame_003EP = dueTimeFrame;
				base._002Ector(observer, cancellationToken);
			}

			protected override bool MoveNextCore(long frameCount)
			{
				if (++currentFrame == _003CdueTimeFrame_003EP)
				{
					PublishOnNext(_003Cvalue_003EP);
					PublishOnCompleted();
					return false;
				}
				return true;
			}
		}

		public ReturnFrameTime(T value, int dueTimeFrame, FrameProvider frameProvider, CancellationToken cancellationToken)
		{
			_003Cvalue_003EP = value;
			_003CdueTimeFrame_003EP = dueTimeFrame;
			_003CframeProvider_003EP = frameProvider;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			ReturnFrameTimeRunnerWorkItem returnFrameTimeRunnerWorkItem = new ReturnFrameTimeRunnerWorkItem(_003Cvalue_003EP, _003CdueTimeFrame_003EP.NormalizeFrame(), observer, _003CcancellationToken_003EP);
			_003CframeProvider_003EP.Register(returnFrameTimeRunnerWorkItem);
			return returnFrameTimeRunnerWorkItem;
		}
	}
}
