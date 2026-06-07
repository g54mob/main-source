using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace LitMotion
{
	[BurstCompile]
	public struct MotionUpdateJob<TValue, TOptions, TAdapter> : IJobParallelFor where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
	{
		[NativeDisableUnsafePtrRestriction]
		internal unsafe MotionData<TValue, TOptions>* DataPtr;

		[ReadOnly]
		public double DeltaTime;

		[ReadOnly]
		public double UnscaledDeltaTime;

		[ReadOnly]
		public double RealDeltaTime;

		[WriteOnly]
		public NativeList<int>.ParallelWriter CompletedIndexList;

		[WriteOnly]
		public NativeArray<TValue> Output;

		public unsafe void Execute([AssumeRange(0L, 2147483647L)] int index)
		{
			MotionData<TValue, TOptions>* ptr = DataPtr + index;
			ref MotionData.MotionState reference = ref ptr->Core.State;
			ref MotionData.MotionParameters reference2 = ref ptr->Core.Parameters;
			MotionStatus status = reference.Status;
			if (Hint.Likely(status == MotionStatus.Scheduled || status == MotionStatus.Delayed || status == MotionStatus.Playing) || Hint.Unlikely(reference.IsPreserved && reference.Status == MotionStatus.Completed))
			{
				if (!Hint.Unlikely(reference.IsInSequence))
				{
					double num = reference2.TimeKind switch
					{
						MotionTimeKind.Time => DeltaTime, 
						MotionTimeKind.UnscaledTime => UnscaledDeltaTime, 
						MotionTimeKind.Realtime => RealDeltaTime, 
						_ => 0.0, 
					};
					double time = reference.Time + num * (double)reference.PlaybackSpeed;
					ptr->Update<TAdapter>(time, out var result);
					Output[index] = result;
				}
			}
			else if ((!reference.IsPreserved && reference.Status == MotionStatus.Completed) || reference.Status == MotionStatus.Canceled)
			{
				CompletedIndexList.AddNoResize(index);
				reference.Status = MotionStatus.Disposed;
			}
		}
	}
}
