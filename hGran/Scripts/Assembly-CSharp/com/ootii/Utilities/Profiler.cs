using System.Collections.Generic;
using System.Diagnostics;

namespace com.ootii.Utilities
{
	public class Profiler
	{
		public string Tag;

		private string mSpacing;

		private int mCount;

		private float mRunTime;

		private float mTotalTime;

		private float mMinTime;

		private float mMaxTime;

		private Stopwatch mTimer;

		private float mTicksPerMillisecond;

		private static Dictionary<string, Profiler> sProfilers;

		public float AverageTime => 0f;

		public float MinTime => 0f;

		public float MaxTime => 0f;

		public float TotalTime => 0f;

		public float Time => 0f;

		public float ElapsedTime => 0f;

		public int Count => 0;

		public Profiler(string rTag)
		{
		}

		public Profiler(string rTag, string rSpacing)
		{
		}

		public void Reset()
		{
		}

		public void Start()
		{
		}

		public float Stop()
		{
			return 0f;
		}

		public override string ToString()
		{
			return null;
		}

		public static Profiler Start(string rProfiler)
		{
			return null;
		}

		public static Profiler Start(string rProfiler, string rSpacing)
		{
			return null;
		}

		public static float Stop(string rProfiler)
		{
			return 0f;
		}

		public static float ProfilerTime(string rProfiler)
		{
			return 0f;
		}

		public static string ToString(string rProfiler)
		{
			return null;
		}

		public static void ScreenWrite(string rProfiler, int rLine)
		{
		}
	}
}
