using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string itLQpqzAbzirdMtzjxKgJfYnuFAg = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
				return false;
			}
			set
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
			}
		}

		public static bool enabled
		{
			get
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
				return false;
			}
			set
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
			}
		}

		public static string logFile
		{
			get
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
				return string.Empty;
			}
			set
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
			}
		}

		public static bool supported
		{
			get
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				mhrOKnijeOzzTRTiabKeMlAFWkSk();
				return 0L;
			}
		}

		private static void mhrOKnijeOzzTRTiabKeMlAFWkSk()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
		}

		public static uint GetMonoHeapSize()
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			mhrOKnijeOzzTRTiabKeMlAFWkSk();
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
