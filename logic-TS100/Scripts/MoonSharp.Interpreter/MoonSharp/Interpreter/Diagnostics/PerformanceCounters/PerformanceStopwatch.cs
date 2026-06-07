using System;
using System.Diagnostics;

namespace MoonSharp.Interpreter.Diagnostics.PerformanceCounters
{
	internal class PerformanceStopwatch : IDisposable, IPerformanceStopwatch
	{
		private Stopwatch m_Stopwatch = new Stopwatch();

		private int m_Count;

		private int m_Reentrant;

		private PerformanceCounter m_Counter;

		public PerformanceStopwatch(PerformanceCounter perfcounter)
		{
			m_Counter = perfcounter;
		}

		public IDisposable Start()
		{
			if (m_Reentrant == 0)
			{
				m_Count++;
				m_Stopwatch.Start();
			}
			m_Reentrant++;
			return this;
		}

		public void Dispose()
		{
			m_Reentrant--;
			if (m_Reentrant == 0)
			{
				m_Stopwatch.Stop();
			}
		}

		public PerformanceResult GetResult()
		{
			PerformanceResult performanceResult = new PerformanceResult();
			performanceResult.Type = PerformanceCounterType.TimeMilliseconds;
			performanceResult.Global = false;
			performanceResult.Name = m_Counter.ToString();
			performanceResult.Instances = m_Count;
			performanceResult.Counter = m_Stopwatch.ElapsedMilliseconds;
			return performanceResult;
		}
	}
}
