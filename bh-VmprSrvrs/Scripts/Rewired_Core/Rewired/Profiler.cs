using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string FmvpIUfvPIRCrUWBQhWrDmXEoKbN = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static string logFile
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool supported => false;

		public static uint usedHeapSize => 0u;

		public static long usedHeapSizeLong => 0L;

		private static void RuDmYJkdKlPZFBmIZwUvEEHuGebjA()
		{
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
		}

		public static uint GetMonoHeapSize()
		{
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			return 0u;
		}

		public static long GetTotalAllocatedMemoryLong()
		{
			return 0L;
		}

		public static uint GetTotalReservedMemory()
		{
			return 0u;
		}

		public static long GetTotalReservedMemoryLong()
		{
			return 0L;
		}

		public static uint GetTotalUnusedReservedMemory()
		{
			return 0u;
		}

		public static long GetTotalUnusedReservedMemoryLong()
		{
			return 0L;
		}
	}
}
