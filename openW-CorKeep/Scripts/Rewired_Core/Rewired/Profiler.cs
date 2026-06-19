using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string BuzzkDDmQtzlSArYYCcyORpgtxVh = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
				return false;
			}
			set
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
			}
		}

		public static bool enabled
		{
			get
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
				return false;
			}
			set
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
			}
		}

		public static string logFile
		{
			get
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
				return string.Empty;
			}
			set
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
			}
		}

		public static bool supported
		{
			get
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				PLXncOCGHGBscVRJDYGgPOtEBZJGA();
				return 0L;
			}
		}

		private static void PLXncOCGHGBscVRJDYGgPOtEBZJGA()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
		}

		public static uint GetMonoHeapSize()
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			PLXncOCGHGBscVRJDYGgPOtEBZJGA();
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
