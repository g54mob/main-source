using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LitMotion
{
	public static class MotionDebugger
	{
		public sealed class TrackingState
		{
			private static readonly Stack<TrackingState> pool = new Stack<TrackingState>(16);

			public Type ValueType;

			public Type OptionsType;

			public Type AdapterType;

			public IMotionScheduler Scheduler;

			public MotionHandle Handle;

			public StackTrace StackTrace;

			public bool CreatedOnEditor;

			public Action OriginalOnCompleteCallback;

			public Action OriginalOnCancelCallback;

			public readonly Action OnCompleteDelegate;

			public readonly Action OnCancelDelegate;

			private TrackingState()
			{
				OnCompleteDelegate = OnComplete;
				OnCancelDelegate = OnCancel;
			}

			public static TrackingState Create()
			{
				if (!pool.TryPop(out var result))
				{
					return new TrackingState();
				}
				return result;
			}

			private void OnComplete()
			{
				try
				{
					OriginalOnCompleteCallback?.Invoke();
				}
				catch (Exception obj)
				{
					MotionDispatcher.GetUnhandledExceptionHandler()?.Invoke(obj);
				}
				if (Handle.IsActive() && !MotionManager.GetDataRef(Handle, checkIsInSequence: false).State.IsPreserved)
				{
					Release();
				}
			}

			private void OnCancel()
			{
				try
				{
					OriginalOnCancelCallback?.Invoke();
				}
				catch (Exception obj)
				{
					MotionDispatcher.GetUnhandledExceptionHandler()?.Invoke(obj);
				}
				Release();
			}

			private void Release()
			{
				trackings.Remove(this);
				ValueType = null;
				OptionsType = null;
				AdapterType = null;
				Scheduler = null;
				Handle = default(MotionHandle);
				StackTrace = null;
				CreatedOnEditor = false;
				OriginalOnCompleteCallback = null;
				OriginalOnCancelCallback = null;
				pool.Push(this);
			}
		}

		public static bool Enabled = false;

		public static bool EnableStackTrace = false;

		private static readonly List<TrackingState> trackings = new List<TrackingState>(16);

		public static IReadOnlyList<TrackingState> Items => trackings;

		public static void AddTracking(MotionHandle motionHandle, IMotionScheduler scheduler, int skipFrames = 3)
		{
			TrackingState trackingState = TrackingState.Create();
			TrackingState trackingState2 = trackingState;
			TrackingState trackingState3 = trackingState;
			(Type, Type, Type) motionType = MotionManager.GetMotionType(motionHandle);
			trackingState.ValueType = motionType.Item1;
			trackingState2.OptionsType = motionType.Item2;
			trackingState3.AdapterType = motionType.Item3;
			trackingState.Scheduler = scheduler;
			trackingState.Handle = motionHandle;
			if (EnableStackTrace)
			{
				trackingState.StackTrace = new StackTrace(skipFrames, fNeedFileInfo: true);
			}
			ref ManagedMotionData managedDataRef = ref MotionManager.GetManagedDataRef(motionHandle, checkIsInSequence: false);
			trackingState.OriginalOnCompleteCallback = managedDataRef.OnCompleteAction;
			managedDataRef.OnCompleteAction = trackingState.OnCompleteDelegate;
			trackingState.OriginalOnCancelCallback = managedDataRef.OnCancelAction;
			managedDataRef.OnCancelAction = trackingState.OnCancelDelegate;
			trackings.Add(trackingState);
		}

		public static void Clear()
		{
			trackings.Clear();
		}
	}
}
