using System;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cysharp.Threading.Tasks;

namespace LitMotion
{
	internal sealed class UniTaskMotionTaskSource : MotionTaskSourceBase, IUniTaskSource, IValueTaskSource, ITaskPoolNode<UniTaskMotionTaskSource>
	{
		private static TaskPool<UniTaskMotionTaskSource> pool;

		private UniTaskMotionTaskSource nextNode;

		private UniTaskCompletionSourceCore<AsyncUnit> core;

		public ref UniTaskMotionTaskSource NextNode => ref nextNode;

		static UniTaskMotionTaskSource()
		{
			TaskPool.RegisterSizeGetter(typeof(UniTaskMotionTaskSource), () => pool.Size);
		}

		private UniTaskMotionTaskSource()
		{
		}

		public static IUniTaskSource Create(MotionHandle motionHandle, CancelBehavior cancelBehavior, bool cancelAwaitOnMotionCanceled, CancellationToken cancellationToken, out short token)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				MotionTaskSourceBase.OnCanceledTokenReceived(motionHandle, cancelBehavior);
				return AutoResetUniTaskCompletionSource.CreateFromCanceled(cancellationToken, out token);
			}
			if (!pool.TryPop(out var result))
			{
				result = new UniTaskMotionTaskSource();
			}
			result.Initialize(motionHandle, cancelBehavior, cancelAwaitOnMotionCanceled, cancellationToken);
			token = result.core.Version;
			return result;
		}

		protected override void SetTaskCanceled(CancellationToken cancellationToken)
		{
			core.TrySetCanceled(cancellationToken);
		}

		protected override void SetTaskCompleted()
		{
			core.TrySetResult(AsyncUnit.Default);
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

		public UniTaskStatus GetStatus(short token)
		{
			return core.GetStatus(token);
		}

		public UniTaskStatus UnsafeGetStatus()
		{
			return core.UnsafeGetStatus();
		}

		public void OnCompleted(Action<object> continuation, object state, short token)
		{
			core.OnCompleted(continuation, state, token);
		}

		private bool TryReturn()
		{
			core.Reset();
			DisposeRegistration();
			RestoreOriginalCallback();
			ResetFields();
			return pool.TryPush(this);
		}
	}
}
