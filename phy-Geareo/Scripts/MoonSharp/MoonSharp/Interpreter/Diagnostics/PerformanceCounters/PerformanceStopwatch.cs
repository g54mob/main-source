using System;
using System.Diagnostics;

namespace MoonSharp.Interpreter.Diagnostics.PerformanceCounters
{
	internal class PerformanceStopwatch : IDisposable, IPerformanceStopwatch
	{
		private Stopwatch m_Stopwatch;

		private int m_Count;

		private int m_Reentrant;

		private PerformanceCounter m_Counter;

		public PerformanceStopwatch(PerformanceCounter perfcounter)
		{
		}

		public IDisposable Start()
		{
			return null;
		}

		public void Dispose()
		{
		}

		public PerformanceResult GetResult()
		{
			return null;
		}
	}
}
