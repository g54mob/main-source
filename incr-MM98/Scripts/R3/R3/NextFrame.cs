using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class NextFrame : Observable<Unit>
	{
		private sealed class NextFrameRunnerWorkItem : CancellableFrameRunnerWorkItemBase<Unit>
		{
			public NextFrameRunnerWorkItem(Observer<Unit> observer, long startFrameCount, CancellationToken cancellationToken)
			{
				_003CstartFrameCount_003EP = startFrameCount;
				base._002Ector(observer, cancellationToken);
			}

			protected override bool MoveNextCore(long frameCount)
			{
				if (_003CstartFrameCount_003EP == frameCount)
				{
					return true;
				}
				PublishOnNext(default(Unit));
				PublishOnCompleted();
				return false;
			}
		}

		public NextFrame(FrameProvider frameProvider, CancellationToken cancellationToken)
		{
			_003CframeProvider_003EP = frameProvider;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			NextFrameRunnerWorkItem nextFrameRunnerWorkItem = new NextFrameRunnerWorkItem(observer, _003CframeProvider_003EP.GetFrameCount(), _003CcancellationToken_003EP);
			_003CframeProvider_003EP.Register(nextFrameRunnerWorkItem);
			return nextFrameRunnerWorkItem;
		}
	}
}
