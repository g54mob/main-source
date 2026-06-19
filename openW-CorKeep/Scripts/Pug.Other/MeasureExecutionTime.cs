using System;
using System.Diagnostics;
using UnityEngine;

public struct MeasureExecutionTime : IDisposable
{
	private Stopwatch sw;

	private string str;

	public MeasureExecutionTime(string str)
	{
		this.str = str;
		sw = Stopwatch.StartNew();
	}

	public void Dispose()
	{
		sw.Stop();
		UnityEngine.Debug.Log($"{str}: completed in {sw.Elapsed.TotalMilliseconds} ms");
	}
}
