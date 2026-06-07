using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string HHwHceaftqmXNLKpebenyJKXmUsk = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
				return false;
			}
			set
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
			}
		}

		public static bool enabled
		{
			get
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
				return false;
			}
			set
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
			}
		}

		public static string logFile
		{
			get
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
				return string.Empty;
			}
			set
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
			}
		}

		public static bool supported
		{
			get
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				PUEEihpjkLjQpeMungudodGjeIoAb();
				return 0L;
			}
		}

		private static void PUEEihpjkLjQpeMungudodGjeIoAb()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
		}

		public static uint GetMonoHeapSize()
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			PUEEihpjkLjQpeMungudodGjeIoAb();
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
