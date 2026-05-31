using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pathfinding
{
	public class AstarProfiler
	{
		public class ProfilePoint
		{
			public Stopwatch watch;

			public int totalCalls;

			public long tmpBytes;

			public long totalBytes;
		}

		private static readonly Dictionary<string, ProfilePoint> profiles;

		private static DateTime startTime;

		public static ProfilePoint[] fastProfiles;

		public static string[] fastProfileNames;

		private AstarProfiler()
		{
		}

		[Conditional("ProfileAstar")]
		public static void InitializeFastProfile(string[] profileNames)
		{
		}

		[Conditional("ProfileAstar")]
		public static void StartFastProfile(int tag)
		{
		}

		[Conditional("ProfileAstar")]
		public static void EndFastProfile(int tag)
		{
		}

		[Conditional("ASTAR_UNITY_PRO_PROFILER")]
		public static void EndProfile()
		{
		}

		[Conditional("ProfileAstar")]
		public static void StartProfile(string tag)
		{
		}

		[Conditional("ProfileAstar")]
		public static void EndProfile(string tag)
		{
		}

		[Conditional("ProfileAstar")]
		public static void Reset()
		{
		}

		[Conditional("ProfileAstar")]
		public static void PrintFastResults()
		{
		}

		[Conditional("ProfileAstar")]
		public static void PrintResults()
		{
		}
	}
}
