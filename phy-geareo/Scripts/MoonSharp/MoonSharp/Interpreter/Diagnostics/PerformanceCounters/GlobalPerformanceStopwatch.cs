using System;
using System.Diagnostics;

namespace MoonSharp.Interpreter.Diagnostics.PerformanceCounters
{
	internal class GlobalPerformanceStopwatch : IPerformanceStopwatch
	{
		private class GlobalPerformanceStopwatch_StopwatchObject : IDisposable
		{
			private Stopwatch m_Stopwatch;

			private GlobalPerformanceStopwatch m_Parent;

			public GlobalPerformanceStopwatch_StopwatchObject(GlobalPerformanceStopwatch parent)
			{
			}

			public void Dispose()
			{
			}
		}

		private int m_Count;

		private long m_Elapsed;

		private PerformanceCounter m_Counter;

		public GlobalPerformanceStopwatch(PerformanceCounter perfcounter)
		{
		}

		private void SignalStopwatchTerminated(Stopwatch sw)
		{
		}

		public IDisposable Start()
		{
			return null;
		}

		public PerformanceResult GetResult()
		{
			return null;
		}
	}
}
