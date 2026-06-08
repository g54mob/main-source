using System.Diagnostics;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class Profiler
	{
		private const string ptSslmSJkzDBIhTTlLyZSICdmVK = "USE_PROFILER must be set in Rewired Core to use the profiler.";

		public static bool enableBinaryLog
		{
			get
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
				return false;
			}
			set
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
			}
		}

		public static bool enabled
		{
			get
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
				return false;
			}
			set
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
			}
		}

		public static string logFile
		{
			get
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
				return string.Empty;
			}
			set
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
			}
		}

		public static bool supported
		{
			get
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
				return false;
			}
		}

		public static uint usedHeapSize
		{
			get
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
				return 0u;
			}
		}

		public static long usedHeapSizeLong
		{
			get
			{
				dOFecWALLuZjWQmxnYVtNVcTsCQL();
				return 0L;
			}
		}

		private static void dOFecWALLuZjWQmxnYVtNVcTsCQL()
		{
			Logger.Log("USE_PROFILER must be set in Rewired Core to use the profiler.");
		}

		[Conditional("ENABLE_PROFILER")]
		public static void AddFramesFromFile(string file)
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name)
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void BeginSample(string name, Object targetObject)
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
		}

		[Conditional("ENABLE_PROFILER")]
		public static void EndSample()
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
		}

		public static uint GetMonoHeapSize()
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
			return 0u;
		}

		public static long GetMonoHeapSizeLong()
		{
			return 0L;
		}

		public static uint GetMonoUsedSize()
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
			return 0u;
		}

		public static long GetMonoUsedSizeLong()
		{
			return 0L;
		}

		public static int GetRuntimeMemorySize(Object o)
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
			return 0;
		}

		public static long GetRuntimeMemorySizeLong(Object o)
		{
			return 0L;
		}

		public static uint GetTotalAllocatedMemory()
		{
			dOFecWALLuZjWQmxnYVtNVcTsCQL();
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
