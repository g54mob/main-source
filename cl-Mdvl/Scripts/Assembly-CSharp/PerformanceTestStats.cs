using System;
using System.IO;
using System.Text;
using UnityEngine;

public struct PerformanceTestStats
{
	public string TestName;

	public int FrameCount;

	public float AverageFrameTime;

	public float MedianFrameTime;

	public float MinFrameTime;

	public float MaxFrameTime;

	public float Duration;

	public float UpperQuartileAverageFrameTime;

	public float AverageFPS => 1f / AverageFrameTime;

	public float MedianFPS => 1f / MedianFrameTime;

	public float MinFPS => 1f / MaxFrameTime;

	public float MaxFPS => 1f / MinFrameTime;

	public float LowerQuartileAverageFPS => 1f / UpperQuartileAverageFrameTime;

	public override string ToString()
	{
		return "{ " + string.Format("{0}: {1:F2}, {2}: {3:F2}, {4}: {5:F2}, {6}: {7:F2}, {8}: {9:F2}, {10}: {11:F2}, {12}: {13}", "Duration", Duration, "LowerQuartileAverageFPS", LowerQuartileAverageFPS, "AverageFPS", AverageFPS, "MedianFPS", MedianFPS, "MinFPS", MinFPS, "MaxFPS", MaxFPS, "FrameCount", FrameCount) + " }";
	}

	public void WriteToCSV(string testName)
	{
		string path = Path.Combine(Application.dataPath, "..");
		path = Path.Combine(path, "autoplay_" + testName + "_perf.csv");
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Duration,LowerQuartileAverageFPS,AverageFPS,MedianFPS,MinFPS,MaxFPS,FrameCount\n");
		stringBuilder.Append($"{Duration:F2},{LowerQuartileAverageFPS:F2},{AverageFPS:F2},{MedianFPS:F2},{MinFPS:F2},{MaxFPS:F2},{FrameCount}");
		File.WriteAllText(path, stringBuilder.ToString());
	}

	public string GetSheetsLineNoTestName(string timestamp)
	{
		return FormattableString.Invariant($"{timestamp},{Duration:F2},{AverageFPS:F2},{MedianFPS:F2},{MinFPS:F2},{MaxFPS:F2},{LowerQuartileAverageFPS:F2}");
	}

	public string GetSheetsLine(string timestamp)
	{
		return FormattableString.Invariant($"{timestamp},{TestName},{Duration:F2},{AverageFPS:F2},{MedianFPS:F2},{MinFPS:F2},{MaxFPS:F2},{LowerQuartileAverageFPS:F2}");
	}
}
