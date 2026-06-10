using System;
using System.Diagnostics;

public struct LebugSeriesTimerJanitor : IDisposable
{
	private readonly Stopwatch stopwatch;

	private readonly string seriesName;

	public LebugSeriesTimerJanitor(string seriesName)
	{
		this.seriesName = seriesName;
		stopwatch = Stopwatch.StartNew();
	}

	public void Dispose()
	{
		stopwatch.Stop();
	}
}
