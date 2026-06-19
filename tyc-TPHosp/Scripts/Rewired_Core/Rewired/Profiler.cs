using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string nMBlgNGFDJapiITvEyNEiMWpluV = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
				return false;
			}
			set
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
			}
		}

		public static bool enabled
		{
			get
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
				return false;
			}
			set
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
			}
		}

		public static string logFile
		{
			get
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
				return string.Empty;
			}
			set
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
			}
		}

		public static bool supported
		{
			get
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				fxWfrlXogEaVmHVHKqauDduDsfL();
				return 0L;
			}
		}

		private static void fxWfrlXogEaVmHVHKqauDduDsfL()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
		}

		public static uint GetMonoHeapSize()
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			fxWfrlXogEaVmHVHKqauDduDsfL();
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
