using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string LqxhTKrqNpxbedctTVuFHvoBoNDe = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
				return false;
			}
			set
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
			}
		}

		public static bool enabled
		{
			get
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
				return false;
			}
			set
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
			}
		}

		public static string logFile
		{
			get
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
				return string.Empty;
			}
			set
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
			}
		}

		public static bool supported
		{
			get
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				DhXzaPcihWyGEclrILvLSbRdEjFh();
				return 0L;
			}
		}

		private static void DhXzaPcihWyGEclrILvLSbRdEjFh()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
		}

		public static uint GetMonoHeapSize()
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			DhXzaPcihWyGEclrILvLSbRdEjFh();
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
