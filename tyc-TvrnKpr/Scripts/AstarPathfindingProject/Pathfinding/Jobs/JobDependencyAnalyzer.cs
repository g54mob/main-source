using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	[StructLayout((LayoutKind)0, Size = 1)]
	internal struct JobDependencyAnalyzer<T> where T : struct
	{
		private struct ReflectionData
		{
			public int[] fieldOffsets;

			public bool[] writes;

			public bool[] checkUninitializedRead;

			public string[] fieldNames;

			public void Build()
			{
			}

			private void Build(Type type, List<int> fields, List<bool> writes, List<bool> reads, List<string> names, int offset, bool forceReadOnly, bool forceWriteOnly, bool forceDisableUninitializedCheck)
			{
			}
		}

		private static ReflectionData reflectionData;

		private static readonly int BufferOffset;

		private static readonly int SpanPtrOffset;

		private static void initReflectionData()
		{
		}

		private static bool HasHash(int[] hashes, int hash, int count)
		{
			return false;
		}

		public static JobHandle GetDependencies(ref T data, JobDependencyTracker tracker)
		{
			return default(JobHandle);
		}

		public static JobHandle GetDependencies(ref T data, JobDependencyTracker tracker, JobHandle additionalDependency)
		{
			return default(JobHandle);
		}

		private static JobHandle GetDependencies(ref T data, JobDependencyTracker tracker, JobHandle additionalDependency, bool useAdditionalDependency)
		{
			return default(JobHandle);
		}

		internal static void Scheduled(ref T data, JobDependencyTracker tracker, JobHandle job)
		{
		}
	}
}
