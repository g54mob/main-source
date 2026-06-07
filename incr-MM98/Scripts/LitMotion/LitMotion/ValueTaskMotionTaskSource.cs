using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using LitMotion.Collections;

namespace LitMotion
{
	internal sealed class ValueTaskMotionTaskSource : MotionTaskSourceBase, IValueTaskSource, ILinkedPoolNode<ValueTaskMotionTaskSource>
	{
		private static LinkedPool<ValueTaskMotionTaskSource> pool;

		private ValueTaskMotionTaskSource nextNode;

		private ManualResetValueTaskSourceCore<object> core;

		private static ValueTaskMotionTaskSource canceledSource;

		public ref ValueTaskMotionTaskSource NextNode => ref nextNode;

		public short Version => core.Version;

		private static ValueTaskMotionTaskSource FromCanceled(out short token)
		{
			if (canceledSource == null)
			{
				canceledSource = new ValueTaskMotionTaskSource();
			}
			canceledSource.core.Reset();
			canceledSource.core.SetException(new OperationCanceledException());
			token = canceledSource.Version;
			return canceledSource;
		}

		private ValueTaskMotionTaskSource()
		{
		}

		public static IValueTaskSource Create(MotionHandle motionHandle, CancelBehavior cancelBehavior, bool cancelAwaitOnMotionCanceled, CancellationToken cancellationToken, out short token)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				MotionTaskSourceBase.OnCanceledTokenReceived(motionHandle, cancelBehavior);
				return FromCanceled(out token);
			}
			if (!pool.TryPop(out var result))
			{
				result = new ValueTaskMotionTaskSource();
			}
			result.Initialize(motionHandle, cancelBehavior, cancelAwaitOnMotionCanceled, cancellationToken);
			token = result.core.Version;
			return result;
		}

		public void GetResult(short token)
		{
			try
			{
				core.GetResult(token);
			}
			finally
			{
				TryReturn();
			}
		}

		public ValueTaskSourceStatus GetStatus(short token)
		{
			return core.GetStatus(token);
		}

		public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags)
		{
			core.OnCompleted(continuation, state, token, flags);
		}

		private bool TryReturn()
		{
			core.Reset();
			DisposeRegistration();
			RestoreOriginalCallback();
			ResetFields();
			return pool.TryPush(this);
		}

		protected override void SetTaskCanceled(CancellationToken cancellationToken)
		{
			core.SetException(new OperationCanceledException());
		}

		protected override void SetTaskCompleted()
		{
			core.SetResult(null);
		}
	}
}
