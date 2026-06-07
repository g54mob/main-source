using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class EveryUpdate : Observable<Unit>
	{
		private sealed class EveryUpdateRunnerWorkItem : CancellableFrameRunnerWorkItemBase<Unit>
		{
			public EveryUpdateRunnerWorkItem(Observer<Unit> observer, CancellationToken cancellationToken)
				: base(observer, cancellationToken)
			{
			}

			protected override bool MoveNextCore(long _)
			{
				PublishOnNext(default(Unit));
				return true;
			}
		}

		public EveryUpdate(FrameProvider frameProvider, CancellationToken cancellationToken)
		{
			_003CframeProvider_003EP = frameProvider;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			EveryUpdateRunnerWorkItem everyUpdateRunnerWorkItem = new EveryUpdateRunnerWorkItem(observer, _003CcancellationToken_003EP);
			_003CframeProvider_003EP.Register(everyUpdateRunnerWorkItem);
			return everyUpdateRunnerWorkItem;
		}
	}
}
