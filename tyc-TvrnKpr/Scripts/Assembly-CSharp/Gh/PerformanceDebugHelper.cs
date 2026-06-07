using System;
using System.Diagnostics;

namespace Gh
{
	public class PerformanceDebugHelper : IDisposable
	{
		private Stopwatch _stopwatch;

		public string Name { get; private set; }

		public PerformanceDebugHelper(string name)
		{
		}

		public void Dispose()
		{
		}
	}
}
