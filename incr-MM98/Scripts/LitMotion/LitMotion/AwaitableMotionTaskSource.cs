using System.Threading;
using UnityEngine;

namespace LitMotion
{
	internal sealed class AwaitableMotionTaskSource : MotionTaskSourceBase
	{
		private static AwaitableMotionTaskSource completedSource;

		private static AwaitableMotionTaskSource canceledSource;

		private readonly AwaitableCompletionSource core = new AwaitableCompletionSource();

		public static AwaitableMotionTaskSource CompletedSource
		{
			get
			{
				if (completedSource == null)
				{
					completedSource = new AwaitableMotionTaskSource();
				}
				completedSource.core.Reset();
				completedSource.core.SetResult();
				return completedSource;
			}
		}

		public static AwaitableMotionTaskSource CanceledSource
		{
			get
			{
				if (canceledSource == null)
				{
					canceledSource = new AwaitableMotionTaskSource();
				}
				canceledSource.core.Reset();
				canceledSource.core.SetCanceled();
				return canceledSource;
			}
		}

		public Awaitable Awaitable => core.Awaitable;

		private AwaitableMotionTaskSource()
		{
		}

		public static AwaitableMotionTaskSource Create(MotionHandle motionHandle, CancelBehavior cancelBehavior, bool cancelAwaitOnMotionCanceled, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				MotionTaskSourceBase.OnCanceledTokenReceived(motionHandle, cancelBehavior);
				return CanceledSource;
			}
			AwaitableMotionTaskSource awaitableMotionTaskSource = new AwaitableMotionTaskSource();
			awaitableMotionTaskSource.Initialize(motionHandle, cancelBehavior, cancelAwaitOnMotionCanceled, cancellationToken);
			return awaitableMotionTaskSource;
		}

		protected override void SetTaskCanceled(CancellationToken cancellationToken)
		{
			core.SetCanceled();
		}

		protected override void SetTaskCompleted()
		{
			core.SetResult();
		}
	}
}
