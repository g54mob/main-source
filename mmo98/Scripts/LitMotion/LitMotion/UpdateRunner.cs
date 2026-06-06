using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace LitMotion
{
	internal sealed class UpdateRunner<TValue, TOptions, TAdapter> : IUpdateRunner where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
	{
		private readonly MotionStorage<TValue, TOptions, TAdapter> storage;

		private double prevTime;

		private double prevUnscaledTime;

		private double prevRealtime;

		public MotionStorage<TValue, TOptions, TAdapter> Storage => storage;

		IMotionStorage IUpdateRunner.Storage => storage;

		public UpdateRunner(MotionStorage<TValue, TOptions, TAdapter> storage, double time, double unscaledTime, double realtime)
		{
			this.storage = storage;
			prevTime = time;
			prevUnscaledTime = unscaledTime;
			prevRealtime = realtime;
		}

		public unsafe void Update(double time, double unscaledTime, double realtime)
		{
			int count = storage.Count;
			using NativeArray<TValue> nativeArray = new NativeArray<TValue>(count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			using NativeList<int> denseIndexList = new NativeList<int>(count, Allocator.TempJob);
			double deltaTime = time - prevTime;
			double unscaledDeltaTime = unscaledTime - prevUnscaledTime;
			double realDeltaTime = realtime - prevRealtime;
			prevTime = time;
			prevUnscaledTime = unscaledTime;
			prevRealtime = realtime;
			fixed (MotionData<TValue, TOptions>* ptr = storage.GetDataSpan())
			{
				IJobParallelForExtensions.Schedule(new MotionUpdateJob<TValue, TOptions, TAdapter>
				{
					DataPtr = ptr,
					DeltaTime = deltaTime,
					UnscaledDeltaTime = unscaledDeltaTime,
					RealDeltaTime = realDeltaTime,
					Output = nativeArray,
					CompletedIndexList = denseIndexList.AsParallelWriter()
				}, count, 16).Complete();
				Span<ManagedMotionData> managedDataSpan = storage.GetManagedDataSpan();
				TValue* unsafePtr = (TValue*)nativeArray.GetUnsafePtr();
				for (int i = 0; i < managedDataSpan.Length; i++)
				{
					ref MotionData.MotionState reference = ref ptr[i].Core.State;
					if (reference.IsInSequence)
					{
						continue;
					}
					MotionStatus status = reference.Status;
					ref ManagedMotionData reference2 = ref managedDataSpan[i];
					if (status != MotionStatus.Playing && status != MotionStatus.Completed && (status != MotionStatus.Delayed || reference2.SkipValuesDuringDelay))
					{
						continue;
					}
					try
					{
						reference2.UpdateUnsafe(in unsafePtr[i]);
					}
					catch (Exception obj)
					{
						MotionDispatcher.GetUnhandledExceptionHandler()?.Invoke(obj);
						if (reference2.CancelOnError)
						{
							reference.Status = MotionStatus.Canceled;
							reference2.OnCancelAction?.Invoke();
						}
					}
					if (reference.WasLoopCompleted)
					{
						reference2.InvokeOnLoopComplete(reference.CompletedLoops);
					}
					if (status == MotionStatus.Completed && reference.WasStatusChanged)
					{
						reference2.InvokeOnComplete();
					}
				}
			}
			storage.RemoveAll(denseIndexList);
		}

		public void Reset()
		{
			prevTime = 0.0;
			prevUnscaledTime = 0.0;
			prevRealtime = 0.0;
			storage.Reset();
		}
	}
}
