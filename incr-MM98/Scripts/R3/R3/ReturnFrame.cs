using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ReturnFrame<T> : Observable<T>
	{
		private sealed class ReturnFrameRunnerWorkItem : CancellableFrameRunnerWorkItemBase<T>
		{
			public ReturnFrameRunnerWorkItem(T value, Observer<T> observer, CancellationToken cancellationToken)
			{
				_003Cvalue_003EP = value;
				base._002Ector(observer, cancellationToken);
			}

			protected override bool MoveNextCore(long frameCount)
			{
				PublishOnNext(_003Cvalue_003EP);
				PublishOnCompleted();
				return false;
			}
		}

		public ReturnFrame(T value, FrameProvider frameProvider, CancellationToken cancellationToken)
		{
			_003Cvalue_003EP = value;
			_003CframeProvider_003EP = frameProvider;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			ReturnFrameRunnerWorkItem returnFrameRunnerWorkItem = new ReturnFrameRunnerWorkItem(_003Cvalue_003EP, observer, _003CcancellationToken_003EP);
			_003CframeProvider_003EP.Register(returnFrameRunnerWorkItem);
			return returnFrameRunnerWorkItem;
		}
	}
}
