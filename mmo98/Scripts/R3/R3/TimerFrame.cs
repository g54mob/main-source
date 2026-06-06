using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class TimerFrame : Observable<Unit>
	{
		private sealed class SingleTimerFrameRunnerWorkItem : CancellableFrameRunnerWorkItemBase<Unit>
		{
			private int currentFrame;

			public SingleTimerFrameRunnerWorkItem(int dueTimeFrame, Observer<Unit> observer, CancellationToken cancellationToken)
			{
				_003CdueTimeFrame_003EP = dueTimeFrame;
				base._002Ector(observer, cancellationToken);
			}

			protected override bool MoveNextCore(long _)
			{
				if (++currentFrame == _003CdueTimeFrame_003EP)
				{
					PublishOnNext(default(Unit));
					PublishOnCompleted();
					return false;
				}
				return true;
			}
		}

		private sealed class MultiTimerFrameRunnerWorkItem : CancellableFrameRunnerWorkItemBase<Unit>
		{
			private int currentFrame;

			private bool isPeriodPhase;

			public MultiTimerFrameRunnerWorkItem(int dueTimeFrame, int periodFrame, Observer<Unit> observer, CancellationToken cancellationToken)
			{
				_003CdueTimeFrame_003EP = dueTimeFrame;
				_003CperiodFrame_003EP = periodFrame;
				base._002Ector(observer, cancellationToken);
			}

			protected override bool MoveNextCore(long _)
			{
				if (!isPeriodPhase)
				{
					if (++currentFrame == _003CdueTimeFrame_003EP)
					{
						PublishOnNext(default(Unit));
						isPeriodPhase = true;
						currentFrame = 0;
					}
					return true;
				}
				if (++currentFrame == _003CperiodFrame_003EP)
				{
					PublishOnNext(default(Unit));
					currentFrame = 0;
				}
				return true;
			}
		}

		public TimerFrame(int dueTimeFrame, int? periodFrame, FrameProvider frameProvider, CancellationToken cancellationToken)
		{
			_003CdueTimeFrame_003EP = dueTimeFrame;
			_003CperiodFrame_003EP = periodFrame;
			_003CframeProvider_003EP = frameProvider;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			_003CdueTimeFrame_003EP = _003CdueTimeFrame_003EP.NormalizeFrame();
			_003CperiodFrame_003EP = _003CperiodFrame_003EP?.NormalizeFrame();
			CancellableFrameRunnerWorkItemBase<Unit> cancellableFrameRunnerWorkItemBase = ((!_003CperiodFrame_003EP.HasValue) ? ((CancellableFrameRunnerWorkItemBase<Unit>)new SingleTimerFrameRunnerWorkItem(_003CdueTimeFrame_003EP, observer, _003CcancellationToken_003EP)) : ((CancellableFrameRunnerWorkItemBase<Unit>)new MultiTimerFrameRunnerWorkItem(_003CdueTimeFrame_003EP, _003CperiodFrame_003EP.Value, observer, _003CcancellationToken_003EP)));
			_003CframeProvider_003EP.Register(cancellableFrameRunnerWorkItemBase);
			return cancellableFrameRunnerWorkItemBase;
		}
	}
}
