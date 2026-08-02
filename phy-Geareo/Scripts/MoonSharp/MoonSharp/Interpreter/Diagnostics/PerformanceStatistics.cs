using System;
using MoonSharp.Interpreter.Diagnostics.PerformanceCounters;

namespace MoonSharp.Interpreter.Diagnostics
{
	public class PerformanceStatistics
	{
		private IPerformanceStopwatch[] m_Stopwatches;

		private static IPerformanceStopwatch[] m_GlobalStopwatches;

		private bool m_Enabled;

		public bool Enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PerformanceResult GetPerformanceCounterResult(PerformanceCounter pc)
		{
			return null;
		}

		internal IDisposable StartStopwatch(PerformanceCounter pc)
		{
			return null;
		}

		internal static IDisposable StartGlobalStopwatch(PerformanceCounter pc)
		{
			return null;
		}

		public string GetPerformanceLog()
		{
			return null;
		}
	}
}
