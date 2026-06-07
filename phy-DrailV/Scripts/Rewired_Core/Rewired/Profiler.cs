using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string ciJroEGLrgaupFifTetfHDIQkitm = "ENABLE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
				return false;
			}
			set
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
			}
		}

		public static bool enabled
		{
			get
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
				return false;
			}
			set
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
			}
		}

		public static string logFile
		{
			get
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
				return string.Empty;
			}
			set
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
			}
		}

		public static bool supported
		{
			get
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				yxGjziJRUdUuxSAZFfRFOrwiwxtq();
				return 0L;
			}
		}

		private static void yxGjziJRUdUuxSAZFfRFOrwiwxtq()
		{
			Logger.Log("ENABLE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
		}

		public static uint GetMonoHeapSize()
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			yxGjziJRUdUuxSAZFfRFOrwiwxtq();
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
