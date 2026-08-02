using System;

namespace MoonSharp.Interpreter.Diagnostics.PerformanceCounters
{
	internal class DummyPerformanceStopwatch : IPerformanceStopwatch, IDisposable
	{
		public static DummyPerformanceStopwatch Instance;

		private PerformanceResult m_Result;

		private DummyPerformanceStopwatch()
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

		public void Dispose()
		{
		}
	}
}
