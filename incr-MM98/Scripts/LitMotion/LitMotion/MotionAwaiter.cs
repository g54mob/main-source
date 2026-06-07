using System;
using System.Runtime.CompilerServices;

namespace LitMotion
{
	public readonly struct MotionAwaiter : ICriticalNotifyCompletion, INotifyCompletion
	{
		private readonly MotionHandle handle;

		public bool IsCompleted => !handle.IsActive();

		public MotionAwaiter(MotionHandle handle)
		{
			this.handle = handle;
		}

		public MotionAwaiter GetAwaiter()
		{
			return this;
		}

		public void GetResult()
		{
		}

		public void OnCompleted(Action continuation)
		{
			UnsafeOnCompleted(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			if (continuation != null)
			{
				ref ManagedMotionData managedDataRef = ref MotionManager.GetManagedDataRef(handle, checkIsInSequence: false);
				ref Action onCompleteAction = ref managedDataRef.OnCompleteAction;
				onCompleteAction = (Action)Delegate.Combine(onCompleteAction, continuation);
				ref Action onCancelAction = ref managedDataRef.OnCancelAction;
				onCancelAction = (Action)Delegate.Combine(onCancelAction, continuation);
			}
		}
	}
}
