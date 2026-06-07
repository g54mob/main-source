using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string LYTliTgKBmHbBwcRiDKJSBxXFkheA = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
				return false;
			}
			set
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
			}
		}

		public static bool enabled
		{
			get
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
				return false;
			}
			set
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
			}
		}

		public static string logFile
		{
			get
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
				return string.Empty;
			}
			set
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
			}
		}

		public static bool supported
		{
			get
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				JASwGpxoNlvGRphEalHhHiBtfFvI();
				return 0L;
			}
		}

		private static void JASwGpxoNlvGRphEalHhHiBtfFvI()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
		}

		public static uint GetMonoHeapSize()
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			JASwGpxoNlvGRphEalHhHiBtfFvI();
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
