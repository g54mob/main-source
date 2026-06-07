using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string PotvpgfgwUMgGZByKeNwJKqSoYUVA = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
				return false;
			}
			set
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
			}
		}

		public static bool enabled
		{
			get
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
				return false;
			}
			set
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
			}
		}

		public static string logFile
		{
			get
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
				return string.Empty;
			}
			set
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
			}
		}

		public static bool supported
		{
			get
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				PrPTrjeJrbwfwOQfNKVcXSugMqGW();
				return 0L;
			}
		}

		private static void PrPTrjeJrbwfwOQfNKVcXSugMqGW()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
		}

		public static uint GetMonoHeapSize()
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			PrPTrjeJrbwfwOQfNKVcXSugMqGW();
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
