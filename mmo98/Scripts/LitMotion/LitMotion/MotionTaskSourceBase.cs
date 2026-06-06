using System;
using System.Threading;

namespace LitMotion
{
	internal abstract class MotionTaskSourceBase
	{
		private readonly Action onCancelCallbackDelegate;

		private readonly Action onCompleteCallbackDelegate;

		private MotionHandle motionHandle;

		private CancelBehavior cancelBehavior;

		private bool cancelAwaitOnMotionCanceled;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationRegistration;

		private Action originalCompleteAction;

		private Action originalCancelAction;

		public MotionTaskSourceBase()
		{
			onCancelCallbackDelegate = OnCancelCallbackDelegate;
			onCompleteCallbackDelegate = OnCompleteCallbackDelegate;
		}

		protected abstract void SetTaskCanceled(CancellationToken cancellationToken);

		protected abstract void SetTaskCompleted();

		protected void OnCancelCallbackDelegate()
		{
			originalCancelAction?.Invoke();
			if (cancellationToken.IsCancellationRequested || cancelAwaitOnMotionCanceled)
			{
				SetTaskCanceled(cancellationToken);
			}
			else
			{
				SetTaskCompleted();
			}
		}

		protected void OnCompleteCallbackDelegate()
		{
			originalCompleteAction?.Invoke();
			if (cancellationToken.IsCancellationRequested)
			{
				SetTaskCanceled(cancellationToken);
			}
			else
			{
				SetTaskCompleted();
			}
		}

		protected static void OnCanceledTokenReceived(MotionHandle motionHandle, CancelBehavior cancelBehavior)
		{
			switch (cancelBehavior)
			{
			case CancelBehavior.Cancel:
				motionHandle.Cancel();
				break;
			case CancelBehavior.Complete:
				motionHandle.Complete();
				break;
			}
		}

		protected void Initialize(MotionHandle motionHandle, CancelBehavior cancelBehavior, bool cancelAwaitOnMotionCanceled, CancellationToken cancellationToken)
		{
			this.motionHandle = motionHandle;
			this.cancelBehavior = cancelBehavior;
			this.cancelAwaitOnMotionCanceled = cancelAwaitOnMotionCanceled;
			this.cancellationToken = cancellationToken;
			ref ManagedMotionData managedDataRef = ref MotionManager.GetManagedDataRef(motionHandle, checkIsInSequence: false);
			originalCancelAction = managedDataRef.OnCancelAction;
			originalCompleteAction = managedDataRef.OnCompleteAction;
			managedDataRef.OnCancelAction = onCancelCallbackDelegate;
			managedDataRef.OnCompleteAction = onCompleteCallbackDelegate;
			if (originalCancelAction == onCancelCallbackDelegate)
			{
				originalCancelAction = null;
			}
			if (originalCompleteAction == onCompleteCallbackDelegate)
			{
				originalCompleteAction = null;
			}
			if (!cancellationToken.CanBeCanceled)
			{
				return;
			}
			cancellationRegistration = RegisterWithoutCaptureExecutionContext(cancellationToken, delegate(object x)
			{
				MotionTaskSourceBase motionTaskSourceBase = (MotionTaskSourceBase)x;
				if (motionTaskSourceBase.motionHandle.IsActive())
				{
					motionTaskSourceBase.RestoreOriginalCallback(checkIsActive: false);
					switch (motionTaskSourceBase.cancelBehavior)
					{
					case CancelBehavior.Cancel:
						motionTaskSourceBase.motionHandle.Cancel();
						break;
					case CancelBehavior.Complete:
						motionTaskSourceBase.motionHandle.Complete();
						break;
					}
					motionTaskSourceBase.SetTaskCanceled(motionTaskSourceBase.cancellationToken);
				}
			}, this);
		}

		protected void ResetFields()
		{
			motionHandle = default(MotionHandle);
			cancelBehavior = CancelBehavior.None;
			cancelAwaitOnMotionCanceled = false;
			cancellationToken = default(CancellationToken);
			originalCompleteAction = null;
			originalCancelAction = null;
		}

		protected void RestoreOriginalCallback(bool checkIsActive = true)
		{
			if (!checkIsActive || motionHandle.IsActive())
			{
				ref ManagedMotionData managedDataRef = ref MotionManager.GetManagedDataRef(motionHandle, checkIsInSequence: false);
				managedDataRef.OnCancelAction = originalCancelAction;
				managedDataRef.OnCompleteAction = originalCompleteAction;
			}
		}

		protected void DisposeRegistration()
		{
			cancellationRegistration.Dispose();
		}

		private static CancellationTokenRegistration RegisterWithoutCaptureExecutionContext(CancellationToken cancellationToken, Action<object> callback, object state)
		{
			bool flag = false;
			if (!ExecutionContext.IsFlowSuppressed())
			{
				ExecutionContext.SuppressFlow();
				flag = true;
			}
			try
			{
				return cancellationToken.Register(callback, state, useSynchronizationContext: false);
			}
			finally
			{
				if (flag)
				{
					ExecutionContext.RestoreFlow();
				}
			}
		}
	}
}
