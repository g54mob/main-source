using System;
using System.Runtime.InteropServices;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;

namespace Pathfinding.Jobs
{
	internal static class JobParallelForBatchedExtensions
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		internal struct ParallelForBatchJobStruct<T> where T : struct, IJobParallelForBatched
		{
			public delegate void ExecuteJobFunction(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);

			public static IntPtr jobReflectionData;

			public static IntPtr Initialize()
			{
				return (IntPtr)0;
			}

			public static void Execute(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex)
			{
			}
		}

		public static JobHandle ScheduleBatch<T>(this T jobData, int arrayLength, int minIndicesPerJobCount, JobHandle dependsOn = default(JobHandle)) where T : struct, IJobParallelForBatched
		{
			return default(JobHandle);
		}

		public static void RunBatch<T>(this T jobData, int arrayLength) where T : struct, IJobParallelForBatched
		{
		}
	}
}
