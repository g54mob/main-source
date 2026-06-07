using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;

namespace Pathfinding.Jobs
{
	public static class JobParallelForBatchedExtensions
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		internal struct ParallelForBatchJobStruct<T> where T : struct, IJobParallelForBatched
		{
			public delegate void ExecuteJobFunction(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);

			public static IntPtr jobReflectionData;

			public static IntPtr Initialize()
			{
				if (jobReflectionData == IntPtr.Zero)
				{
					jobReflectionData = JobsUtility.CreateJobReflectionData(typeof(T), new ExecuteJobFunction(Execute));
				}
				return jobReflectionData;
			}

			public static void Execute(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex)
			{
				int beginIndex;
				int endIndex;
				while (JobsUtility.GetWorkStealingRange(ref ranges, jobIndex, out beginIndex, out endIndex))
				{
					jobData.Execute(beginIndex, endIndex - beginIndex);
				}
			}
		}

		public unsafe static JobHandle ScheduleBatch<T>(this T jobData, int arrayLength, int minIndicesPerJobCount, JobHandle dependsOn = default(JobHandle)) where T : struct, IJobParallelForBatched
		{
			ScheduleMode i_scheduleMode = ScheduleMode.Batched;
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref jobData), ParallelForBatchJobStruct<T>.Initialize(), dependsOn, i_scheduleMode);
			return JobsUtility.ScheduleParallelFor(ref parameters, arrayLength, minIndicesPerJobCount);
		}

		public unsafe static void RunBatch<T>(this T jobData, int arrayLength) where T : struct, IJobParallelForBatched
		{
			JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref jobData), ParallelForBatchJobStruct<T>.Initialize(), default(JobHandle), ScheduleMode.Run);
			JobsUtility.ScheduleParallelFor(ref parameters, arrayLength, arrayLength);
		}
	}
}
